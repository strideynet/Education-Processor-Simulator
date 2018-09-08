namespace EPS.Processor
{
    public class Processor
    {
        private Register[] _registers;

        public Processor()
        {
            InitRegisters();
        }

        private void InitRegisters()
        {
            _registers = new Register[16]; // 16 Total Register spaces according to the spec
            
            for (var i = 0; i < 10; i++) // Generate the 10 General Purpose Registers
            {
                _registers[i] = new Register($"General Purpose R{i}");
            }

            _registers[13] = new Register("Program Counter");
            _registers[14] = new Register("Flag Register");
            _registers[15] = new Register("Stack Pointer");
        }
    }
}