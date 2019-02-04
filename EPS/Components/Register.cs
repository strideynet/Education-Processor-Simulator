using System;

namespace EPS.Components
{
    [Flags]
    public enum BusFlags : byte
    {
        Read = 0b0001,
        Write = 0b0010,
        SecondWord = 0b0100
    }

    public class Register
    {
        private BusFlags _flags;
        private Processor _proc;
        private Bus _bus;
        private byte[] _value;

        public byte[] Value
        {
            get => _value;
            set => _value = value;
        }

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
                var outputArray = new byte[2];
                Array.Copy(_value, _flags.HasFlag(BusFlags.SecondWord) ? 2 : 0, outputArray, 0, 2);
                _bus.Write(_value);
            }
        }

        private void ClockFallingHandler()
        {
            if (_flags.HasFlag(BusFlags.Write))
            {
                var inputArray = _bus.Read();
                Array.Copy(inputArray, 0, _value, _flags.HasFlag(BusFlags.SecondWord) ? 2 : 0, 2);
            }

            _flags = 0; // Reset flags.
        }
    }
}