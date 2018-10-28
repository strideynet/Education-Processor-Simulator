using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using EPS.Components;
using EPS.Instructions;

namespace EPS
{
    public partial class Processor
    {
        public InstructionSet InstructionSet = new InstructionSet();

        public readonly Bus AddressBus;
        public readonly Bus SystemBus;

        public readonly Register CIR;
        public readonly Register PC;
        public readonly Register MDR;
        public readonly Register MAR;
        public readonly Register ACC;

        public readonly ALU ALU;

        public bool Fetching = true; // true for fetch, false for execute
        
        private Instruction Fetch = new Instruction
        {
            InstructionStages = new List<InstructionStage> //Microcode for the Fetch instruction
            {
                proc => //0
                {
                    proc.PC.SetFlag(BusFlags.Read); // PC -> MAR
                    proc.MAR.SetFlag(BusFlags.Write);
                    
                    proc.ALU.SetMode(ALUModes.IncrementWord); // Increment value and store in ACC

                    return null;
                },
                proc => //1
                {
                    proc.MDR.SetFlag(BusFlags.Read); // MDR -> CIR/ALU
                    proc.CIR.SetFlag(BusFlags.Write);

                    return null;
                },
                proc => //2
                {
                    proc.ACC.SetFlag(BusFlags.Read); // ACC -> MAR
                    proc.MAR.SetFlag(BusFlags.Write);
                    
                    proc.ALU.SetMode(ALUModes.IncrementWord); // Increment value and store in ACC

                    return null;
                },
                proc => //3
                {
                    proc.MDR.SetFlag(BusFlags.Read); // MDR -> CIR Second word
                    proc.CIR.SetFlag(BusFlags.SecondWord);
                    proc.CIR.SetFlag(BusFlags.Write);

                    return null;
                },
                proc => //4
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
        }


        public event ClockRisingHandler ClockRising;
        public event ClockFallingHandler ClockFalling;
        public event UpdateUIHandler UpdateUI;
        
        public delegate void ClockRisingHandler();
        public delegate void ClockFallingHandler();
        public delegate void UpdateUIHandler();

        public void Clock()
        {   
            if (Fetching)
            {
                Fetching = !Fetch.Execute(this);
            }
            else
            {
                Instruction currentInstruction = null;
                int instructionValue = CIR.Value[0] & 0b0011_1111;

                currentInstruction = InstructionSet.Instructions[instructionValue];
                
                Fetching = currentInstruction.Execute(this);
            }
            
            ClockRising(); // Write to Bus
            ClockFalling(); // Read from bus and operate
            UpdateUI();
            
            WriteState();
        }
    }
}