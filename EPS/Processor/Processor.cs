using System;
using System.Collections.Generic;
using EPS.Components;
using EPS.Instructions;

namespace EPS {
    // Possible acceptable memory modes.
    public enum MemoryMode
    {
        Immediate,
        Direct,
        Register
    }

    // Provided to instructions as context for the execution.
    public struct ProcessorExecutionContext {
        public int FullInstruction;
        public int Opcode;
        public MemoryMode MemoryMode;
        public Processor Proc;
        public int StageCount;
        public Register RegA;
        public Register RegB;
        public short? Immediate; //16bit
        public ushort? MemoryAddress; //16bit unsigned
    }

    public partial class Processor
    {
        public InstructionSet InstructionSet = new InstructionSet();
        public readonly Bus SystemBus;

        public readonly Register CIR;
        public readonly Register PC;
        public readonly Register MDR;
        public readonly Register MAR;
        public readonly Register ACC;

        public readonly ALU ALU;

        public readonly Components.MemoryBank MemoryBank;

        public readonly Register[] RegisterBank = new Register[256];

        public bool Fetching = true; // true for fetch, false for execute
        
        private Instruction Fetch = new Instruction
        {
            InstructionStages = new List<InstructionStage> //Microcode for the Fetch instruction
            {
                (proc, ctx) => //0
                {
                    proc.PC.SetFlag(BusFlags.Read); // PC -> MAR
                    proc.MAR.SetFlag(BusFlags.Write);
                    
                    proc.ALU.SetMode(ALUModes.IncrementWord); // Increment value and store in ACC

                    proc.MemoryBank.SetFlag(MemoryFlags.Read);
                    proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);

                    return null;
                },
                (proc, ctx) => //1
                {
                    proc.MDR.SetFlag(BusFlags.Read); // MDR -> CIR/ALU
                    proc.CIR.SetFlag(BusFlags.Write);

                    return null;
                },
                (proc, ctx) => //2
                {
                    proc.ACC.SetFlag(BusFlags.Read); // ACC -> MAR
                    proc.MAR.SetFlag(BusFlags.Write);

                    proc.MemoryBank.SetFlag(MemoryFlags.Read);
                    proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);

                    proc.ALU.SetMode(ALUModes.IncrementWord); // Increment value and store in ACC

                    return null;
                },
                (proc, ctx) => //3
                {
                    proc.MDR.SetFlag(BusFlags.Read); // MDR -> CIR Second word
                    proc.CIR.SetFlag(BusFlags.SecondWord);
                    proc.CIR.SetFlag(BusFlags.Write);

                    return null;
                },
                (proc, ctx) => //4
                {
                    proc.ACC.SetFlag(BusFlags.Read); // ACC -> PC. PC is now fully incremented 2 words.
                    proc.PC.SetFlag(BusFlags.Write);

                    return null;
                }
            }
        };

        public Processor()
        {
            SystemBus = new Bus(2);
            
            CIR = new Register(this, SystemBus, 4); // Instructions have 2 words
            PC = new Register(this, SystemBus, 2);
            MDR = new Register(this, SystemBus, 2);
            MAR = new Register(this, SystemBus, 2);
            
            ACC = new Register(this, SystemBus, 2); // TODO: Ensure Accumulator is referencable by instructions as a User register.
            
            ALU = new ALU(this, SystemBus, ACC);

            for (int i = 0; i < 8; i++)
            {
                RegisterBank[i] = new Register(this, SystemBus, 2); // Generate general registers.
            }
            RegisterBank[0b1000_0000] = CIR; // Set special registers.
            RegisterBank[0b1000_0001] = PC;
            RegisterBank[0b1000_0010] = MDR;
            RegisterBank[0b1000_0011] = MAR;
            RegisterBank[0b1000_0100] = ACC;


            MemoryBank = new Components.MemoryBank(this, MDR, MAR);
        }


        // Setup events and delegates.
        public event ClockRisingHandler ClockRising;
        public event ClockFallingHandler ClockFalling;
        public event UpdateUIHandler UpdateUI;
        
        public delegate void ClockRisingHandler();
        public delegate void ClockFallingHandler();
        public delegate void UpdateUIHandler();

        public void Clock()
        {
            var ctx = new ProcessorExecutionContext // Setup execution context
            {
                FullInstruction = CIR.Value[0],
                Opcode = CIR.Value[0] & 0b0011_1111,
                MemoryMode = (MemoryMode) ((CIR.Value[0] & 0b1100_0000) >> 6),
                Proc = this,
                RegA = RegisterBank[CIR.Value[1]]
            };

            // Setup execution context for specific memorymode.
            if (ctx.MemoryMode == MemoryMode.Register)
            {
                ctx.RegB = RegisterBank[CIR.Value[2]];
            } else if (ctx.MemoryMode == MemoryMode.Immediate)
            {
                ctx.Immediate = BitConverter.ToInt16(CIR.Value, 2);
            } else if (ctx.MemoryMode == MemoryMode.Direct)
            {
                ctx.MemoryAddress = BitConverter.ToUInt16(CIR.Value, 2);
            }

            // Main execution logic.
            if (Fetching)
            {
                Fetching = !Fetch.Execute(ctx);
            }
            else
            {
                var currentInstruction = InstructionSet.Instructions[ctx.Opcode]
                    ?? InstructionSet.Instructions[0]; //Fallback to NOP if instruction does not exist.
               
                Fetching = currentInstruction.Execute(ctx);
            }
            
            ClockRising(); // Write to Bus
            ClockFalling(); // Read from bus and operate
            MemoryBank.ClockFallingHandler();
            UpdateUI();
            
            WriteState();
        }
    }
}  