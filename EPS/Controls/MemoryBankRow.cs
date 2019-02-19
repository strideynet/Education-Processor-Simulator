using System;
using System.Windows.Forms;

namespace EPS
{
    public partial class MemoryBankRow : UserControl
    {
        private readonly MemoryBankCell[] _cells = new MemoryBankCell[8]; // 7 cells of 1 byte = 8 bytes per row.

        public MemoryBankRow()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                _cells[i] = new MemoryBankCell
                {
                    Location = new System.Drawing.Point((i * 120) + 120, 0) // Setup positions programtically
                };

                Controls.Add(_cells[i]);
            }
        }

        public void Setup(Int32 memoryStart, EPS.Components.MemoryBank memory = null)
        {
            lblAddressStart.Text = Convert.ToString(memoryStart, 2).PadLeft(16, '0'); // String formatting for binary style to 16 bits.

            lblAddressEnd.Text = Convert.ToString(memoryStart + 7, 2).PadLeft(16, '0');

            for (int i = 0; i < 8; i++)
            {
                _cells[i].Setup(memoryStart + i, memory); // Propogate setup to cells.a
            }
        }
    }
}
