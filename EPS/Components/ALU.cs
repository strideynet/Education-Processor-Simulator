using System;
using System.Windows.Forms;

namespace EPS.Components
{
    public enum ALUModes: byte
    {
        None,
        Increment,
        Decrement,
        Add,
        Subtract,
        And,
        Or,
        Xor
    }
    
    public class ALU
    {
        private Register _acc; // Special reference to ACC. Can access without using main bus.
        private Processor _proc;
        private Bus _bus;

        private ALUModes _aluMode;

        public ALU(Processor proc, Bus bus, Register acc)
        {
            _acc = acc;
            _bus = bus;
            _proc = proc;
            
            _proc.ClockFalling += ClockFallingHandler;
        }

        public void SetMode(ALUModes mode)
        {
            _aluMode = mode;
        }

        /// <summary>
        /// Calculates answer and writes this into the Accumulator. Pulls data from bus hence falling.
        /// </summary>
        private void ClockFallingHandler()
        {
            if (_aluMode != ALUModes.None)
            {
                var busValue = BitConverter.ToInt16(_bus.Read(), 0);
                var accValue = BitConverter.ToInt16(_acc.Value, 0);

                switch (_aluMode)
                {
                    case ALUModes.Increment:
                        _acc.Value = BitConverter.GetBytes(busValue += 1);
                        break;
                    case ALUModes.Add:
                        _acc.Value = BitConverter.GetBytes(busValue + accValue);
                        break;
                }
            }
        }

    }
}