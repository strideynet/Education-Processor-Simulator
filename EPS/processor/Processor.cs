using System;
using System.Diagnostics;
using System.Security.Cryptography;
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

            _memory = new Memory(65536); // 16 bit address space gives 65536 Bytes
        }

        private void InitRegisters()
        {
            _registers = new Register[19]; // 16 Total Register spaces according to the spec
            
            for (var i = 0; i < 10; i++) // Generate the 10 General Purpose Registers
            {
                _registers[i] = new Register($"General Purpose R{i}");
            }

            _registers[12] = new Register("Program Counter");
            _registers[13] = new Register("Flag Register");
            _registers[14] = new Register("Stack Pointer");
            // 1111 (15) is reserved for showing no register in instructions. Below registers are unaddressable by software and are just for display.
            _registers[16] = new Register("Memory Address Register");
            _registers[17] = new Register("Memory Data Register");
            _registers[18] = new Register("Current Instruction Register");
        }

        public void Draw(int x, int y, int width, int height)
        {
            throw new System.NotImplementedException();
        }

        public void Cycle()
        {
          
            Fetch();
            Decode();
            Execute();
        }

        private void Fetch()
        {
            UInt16 currentAddress = BitConverter.ToUInt16(_registers[12].Read(), 0);
            Console.WriteLine("currentAddress {0}", currentAddress);
            byte[] instruction = _memory.ReadBytes(currentAddress, 2);

            _registers[18].Write(instruction); // Read first 2 bytes into CIR

            UInt16 step = 1;

            // We need to read the last 4 bits to determine how much to step the CIR by. 1111 signifies it is a 2 word instruction.
            if ((instruction[1] & 15) == 15)
            {
                step = 2;
            }

            _registers[12].Write(BitConverter.GetBytes(currentAddress + step)); // Increment PC
            Console.WriteLine("steppedAddress {0}", currentAddress + step);
        }

        private void Decode()
        {

        }

        private void Execute()
        {

        }
    }
}
