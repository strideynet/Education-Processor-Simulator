using System.Collections.Generic;
using EPS.Components;
using EPS.Instructions;

namespace EPS
{
    public class Processor
    {
        public InstructionSet InstructionSet;

        public Bus AddressBus;
        public Bus SystemBus;

        public Register CIR;
        public Register PC;
        public Register MDR;
        public Register MAR;

        public bool Fetching = true; // true for fetch, false for execute
        
        private Instruction Fetch = new Instruction
        {
            InstructionStages = new List<InstructionStage>
            {
                proc =>
                {
                    proc.PC.SetFlag(BusFlags.Read);
                    proc.MAR.SetFlag(BusFlags.Write);
                },
                proc =>
                {
                    proc.MDR.SetFlag(BusFlags.Read);
                    proc.CIR.SetFlag(BusFlags.Write);
                    proc.ALU.SetFlag(BusFlags.Write);
                },
                proc =>
                {
                    proc.ALU.Mode(ALUModes.Increment);
                    proc.ALU.SetFlag(BusFlags.Read);
                    proc.PC.SetFlag(BusFlags.Write);
                }
            }
        };


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
            
            ClockRising();
            ClockFalling();
        }
    }
}