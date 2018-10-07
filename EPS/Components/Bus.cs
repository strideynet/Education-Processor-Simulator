namespace EPS.Components
{
    public class Bus
    {
        private byte[] _value;

        public byte[] Value
        {
            get => _value;
            set => _value = value;
        }
        
        public Bus(int length)
        {
            _value = new byte[length];
        }

        public void Write(byte[] data) => _value = data;

        public byte[] Read() => _value;
    }
}