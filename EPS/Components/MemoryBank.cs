using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace EPS.Components
{
    [Flags]
    public enum MemoryFlags : byte
    {
        Read = 0b0001,
        Write = 0b0010,
        TwoBytes = 0b0100
    }

    public class MemoryBank
    {
        private byte[] _data = new byte[65535];
        private MemoryFlags _flags;
        private Register _mdr;
        private Register _mar;

        public MemoryBank(Register mdr, Register mar)
        {
            _mdr = mdr;
            _mar = mar;
        }

        public void SetFlag(MemoryFlags flag)
        {
            _flags = _flags | flag;
        }

        private void ClockFallingHandler()
        {
            if (_flags.HasFlag(MemoryFlags.Read))
            {
                if (!_flags.HasFlag(MemoryFlags.TwoBytes))
                    _mdr.Value = BitConverter.GetBytes(_data[BitConverter.ToUInt16(_mar.Value, 0)]);
                else
                {

                }
            } else if (_flags.HasFlag(MemoryFlags.Write))
            {
                if (!_flags.HasFlag(MemoryFlags.TwoBytes))
                    _data[BitConverter.ToUInt16(_mar.Value, 0)] = _mdr.Value[0]; //little endian system, first byte least significant
            }

            _flags = 0; // Reset flags.
        }
    }
}
