using System;

namespace EPS.Processor
{
    public class Memory : IDrawable
    {
        private readonly int _length;
        private byte[] _data;

        public Memory(int length)
        {
            _length = length;

            InitializeMemory();
        }

        private void InitializeMemory()
        {
            _data = new byte[_length];
        }

        public byte ReadByte(int addr)
        {
            return _data[addr];
        }

        public byte[] ReadBytes(int addr, int length)
        {
            byte[] data = new byte[length];

            for (var i = 0; i < length; i++)
            {
                data[i] = _data[addr + i];
            }

            return data;
        }

        public void WriteByte(int addr, byte val)
        {
            _data[addr] = val;
        }

        public void WriteBytes(int addr, byte[] val)
        {
            for (var i = 0; i < val.Length; i++)
            {
                _data[addr + i] = val[i];
            }
        }

        public void Draw(int x, int y, int width, int height)
        {
            throw new System.NotImplementedException();
        }

    }
}