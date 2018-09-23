using System;
using System.Runtime.CompilerServices;

namespace EPS.Components
{
    [Flags]
    public enum BusFlags : byte
    {
        Read = 0b0001,
        Write = 0b0010
    }

    public class Register
    {
        private BusFlags flags;
        private Processor proc;

        public Register(Processor proc)
        {
            this.proc = proc;

            this.proc.ClockRising += ClockRisingHandler;
            this.proc.ClockFalling += ClockFallingHandler;
        }

        public void SetFlag(BusFlags flag)
        {
            flags = flags | flag;
        }

        private void ClockRisingHandler()
        {
            if (flags.HasFlag(BusFlags.Write))
            {
                // Set bus to my value
            }
        }

        private void ClockFallingHandler()
        {
            if (flags.HasFlag(BusFlags.Read))
            {
                // Read bus into my value
            }  
        }
    }
}