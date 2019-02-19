using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace EPS.Components
{
    // Possible memory operation modes.
    [Flags]
    public enum MemoryFlags : byte
    {
        Read = 0b0001,
        Write = 0b0010,
        TwoBytes = 0b0100
    }

    public class MemoryBank
    {
        private readonly byte[] _data = new byte[65535]; // Maximal addressable size in case of 16 bit system, with the minimal addressable unit being byte.
        private MemoryFlags _flags;
        private readonly Register _mdr;
        private readonly Register _mar;

        public MemoryBank(Processor proc, Register mdr, Register mar)
        {
            _mdr = mdr;
            _mar = mar;
        }

        public void SetFlag(MemoryFlags flag)
        {
            _flags = _flags | flag;
        }

        public void ClockFallingHandler()
        {
            UInt16 marAddress = BitConverter.ToUInt16(_mar.Value, 0); // Cast to Uint from Byte for easier handling.
            if (_flags.HasFlag(MemoryFlags.Read))
            {
                _mdr.Value[0] = _data[marAddress];
                if (_flags.HasFlag(MemoryFlags.TwoBytes))
                    _mdr.Value[1] = _data[marAddress + 1];
                else
                    _mdr.Value[1] = 0; //Reset most significant byte. Don't want to copy previous value.
            } else if (_flags.HasFlag(MemoryFlags.Write))
            {
                _data[marAddress] = _mdr.Value[0];
                if (_flags.HasFlag(MemoryFlags.TwoBytes))
                    _data[marAddress + 1] = _mdr.Value[1];
            }

            _flags = 0; // Reset flags.
        }

        // Allow memory bank to be indexed as if it was an array.
        public byte this[UInt16 addr]
        {
            get { return _data[addr]; }

            set
            {
                _data[addr] = value;
            }
        }
    }
}
