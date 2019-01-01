using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPS
{
    public partial class MemoryBank : UserControl
    {
        private readonly MemoryBankRow[] _rows = new MemoryBankRow[8];

        private Int32 _memoryStartAddress;

        public Int32 MemoryStartAddress
        {
            get => _memoryStartAddress;

            set
            {
                _memoryStartAddress = value;
                SetupMemoryBank();
            }
        }

        public MemoryBank()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                _rows[i] = new MemoryBankRow {Location = new System.Drawing.Point(0, i * 65)};

                Controls.Add(_rows[i]);
            }

            SetupMemoryBank();
        }


        public void SetupMemoryBank()
        {
            for (int i = 0; i < 8; i++)
            {
                _rows[i].SetupMemoryRow(MemoryStartAddress + i * 8);
            }
        }

        public void StepMemoryPage(int pages)
        {
            MemoryStartAddress += 64 * pages;
        }
    }
}
