﻿using System;
using System.Windows.Forms;

namespace EPS
{
    public partial class MemoryBankControls : UserControl
    {
        private MemoryBank _memoryBank = null;

        public MemoryBankControls()
        {
            InitializeComponent();
        }

        public void Setup(MemoryBank memoryBank)
        {
            _memoryBank = memoryBank;
            UpdateLabels();
        }

        private void StepBack(object sender, EventArgs e)
        {
            _memoryBank.StepMemoryPage(-1); // Use page step helper to ensure pages remain equal size.
            UpdateLabels();
        }

        private void StepForward(object sender, EventArgs e)
        {
            _memoryBank.StepMemoryPage(1);
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lblMemoryStart.Text = Convert.ToString(_memoryBank.MemoryStartAddress, 2).PadLeft(16, '0'); // Binary formatting to 16 bit number even if shorter.
            lblMemoryEnd.Text = Convert.ToString(_memoryBank.MemoryStartAddress + 63, 2).PadLeft(16, '0');

            btnStepPageBack.Enabled = !(_memoryBank.MemoryStartAddress - 64 < 0); // Prevent user overflowing.
            btnStepPageForward.Enabled = !(_memoryBank.MemoryStartAddress + 127 > 65535); // Ensure MemoryEndAddress will not overflow
        }
    }
}
