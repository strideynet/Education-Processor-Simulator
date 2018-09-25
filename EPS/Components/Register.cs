using System;

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
        private BusFlags _flags;
        private Processor _proc;
        private Bus _bus;

        private byte[] _value;

        public Register(Processor proc, Bus bus, int length)
        {
            _proc = proc;

            _proc.ClockRising += ClockRisingHandler;
            _proc.ClockFalling += ClockFallingHandler;

            _bus = bus;
            
            _value = new byte[length];
        }

        public void SetFlag(BusFlags flag)
        {
            _flags = _flags | flag;
        }

        private void ClockRisingHandler()
        {
            if (_flags.HasFlag(BusFlags.Read))
            {
                _bus.Write(_value);
            }
        }

        private void ClockFallingHandler()
        {
            if (_flags.HasFlag(BusFlags.Write))
            {
                _value = _bus.Read();
            }
        }
    }
}