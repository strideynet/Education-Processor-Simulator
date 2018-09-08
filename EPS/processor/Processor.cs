using System;
using System.Diagnostics;
using System.Security.Permissions;

namespace EPS.Processor
{
    public class Processor : IDrawable
    {
        private Register[] _registers;
        private Memory _memory;

        public Processor()
        {
            InitRegisters();

            _memory = new Memory(65536);
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

        public void Draw(int x, int y, int width, int height)
        {
            throw new System.NotImplementedException();
        }

        public void Cycle()
        {
            int currentAddress = BitConverter._registers[13].Read()
            LoadInstruction();

        }

        private void LoadInstruction(int addr)
        {

        }
    }
}
