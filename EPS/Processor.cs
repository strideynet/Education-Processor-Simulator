using System.Collections.Generic;
using EPS.Components;
using EPS.Instructions;

namespace EPS
{
    public class Processor
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
            InstructionStages = new List<InstructionStage>
            {
                proc =>
                {
                    proc.PC.SetFlag(BusFlags.Read); // PC -> MAR
                    proc.MAR.SetFlag(BusFlags.Write);
                },
                proc =>
                {
                    proc.MDR.SetFlag(BusFlags.Read); // MDR -> CIR/ALU
                    proc.CIR.SetFlag(BusFlags.Write);

                    proc.ALU.SetMode(ALUModes.Increment); // Increment value and store in ACC
                },
                proc =>
                {
                    proc.ACC.SetFlag(BusFlags.Read); // ACC -> PC
                    proc.PC.SetFlag(BusFlags.Write);
                }
            }
        };

        public Processor()
        {
            SystemBus = new Bus(2);
            
            CIR = new Register(this, SystemBus, 4); // 2 Word instructions are possible. Hence 32 bit reg.
            PC = new Register(this, SystemBus, 2);
            MDR = new Register(this, SystemBus, 2);
            MAR = new Register(this, SystemBus, 2);
            
            ACC = new Register(this, SystemBus, 2); // TODO: Ensure Accumulator is referencable by instructions as a User register.
        }


        public event ClockRisingHandler ClockRising;
        public event ClockFallingHandler ClockFalling;

        public delegate void ClockRisingHandler();
        public delegate void ClockFallingHandler();

        public void Clock()
        {
            if (Fetching)
            {
                Fetching = !Fetch.Execute(this);
            }
            else
            {
                Fetching = true; // Eventually replace with execute. This will ensure a fetch loop.
            }
            
            ClockRising(); // Write to Bus
            ClockFalling(); // Read from bus and operate
        }
    }
}