using System;

namespace EPS.Processor
{
    class Register : IDrawable
    {
        private string _name;
        private int _size = 2;
        private byte[] _data;

        public Register(string name)
        {
            _name = name;

            _data = new byte[_size];
        }

        public void Write(byte[] data)
        {
            _data = data;
        }

        public byte[] Read()
        {
            return _data;
        }

        public void Draw(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
