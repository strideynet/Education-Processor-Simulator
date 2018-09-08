using System;

namespace EPS.Processor
{
    class Register : IDrawable
    {
        private string _name;
        private int _size = 4;
        private byte[] _data;

        public byte[] Data
        {
            get => _data;
            set => _data = value;
        }

        public Register(string name)
        {
            _name = name;

            _data = new byte[_size];
        }

        public void Draw(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
