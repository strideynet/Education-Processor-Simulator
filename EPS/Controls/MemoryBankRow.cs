using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPS
{
    public partial class MemoryBankRow : UserControl
    {
        private readonly MemoryBankCell[] _cells = new MemoryBankCell[8];

        public MemoryBankRow()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                _cells[i] = new MemoryBankCell
                {
                    Location = new System.Drawing.Point((i * 120) + 120, 0)
                };

                Controls.Add(_cells[i]);
            }
        }

        public void Setup(Int32 memoryStart, EPS.Components.MemoryBank memory = null)
        {
            lblAddressStart.Text = Convert.ToString(memoryStart, 2).PadLeft(16, '0');

            lblAddressEnd.Text = Convert.ToString(memoryStart + 7, 2).PadLeft(16, '0');

            for (int i = 0; i < 8; i++)
            {
                _cells[i].Setup(memoryStart + i, memory);
            }
        }
    }
}
