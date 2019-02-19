using System;
using System.Windows.Forms;

namespace EPS
{
    public partial class MemoryBank : UserControl
    {
        private readonly MemoryBankRow[] _rows = new MemoryBankRow[8]; // 8 rows of 8 gives 64 bytes per page

        private Int32 _memoryStartAddress; // Address to start memorybank on.

        public Int32 MemoryStartAddress
        {
            get => _memoryStartAddress;

            private set
            {
                _memoryStartAddress = value;
                Setup(); // Trigger setup on change of page. This setup propoagates down to the individual cell.
            }
        }

        public MemoryBank()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                _rows[i] = new MemoryBankRow {Location = new System.Drawing.Point(0, i * 65)}; // Setup rows and positions programatically.

                Controls.Add(_rows[i]);
            }

            Setup();
        }

        public void Setup(EPS.Components.MemoryBank memory = null)
        {
            for (int i = 0; i < 8; i++)
            {
                _rows[i].Setup(MemoryStartAddress + i * 8, memory); // Trigger setup propagation.
            }
        }

        public void StepMemoryPage(int pages) // Helper method to ensure steps are equal 64 byte chunks.
        {
            MemoryStartAddress += 64 * pages;
        }
    }
}
