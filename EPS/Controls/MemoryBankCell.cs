using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPS
{
    public partial class MemoryBankCell : UserControl
    {
        private Components.MemoryBank _memory = null;
        private Int32 _memoryAddress;
 
        public MemoryBankCell()
        {
            InitializeComponent();
        }

        public void Setup(Int32 memoryAddress, EPS.Components.MemoryBank memory = null)
        {
            string memoryAddressString = Convert.ToString(memoryAddress, 2).PadLeft(3, '0');
            lblAddress.Text = "Address " + memoryAddressString.Substring(memoryAddressString.Length - 3);

            _memory = memory ?? _memory;
            _memoryAddress = memoryAddress;

            UpdateCell();
        }

        public void UpdateCell()
        {
            if (!(_memory is null))
            {
                txtBox.Text = Convert.ToString(_memory[(ushort)_memoryAddress], 2).PadLeft(8, '0');
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            if (txtBox.Text.Length > 0)
            {
                try
                {
                    _memory[(ushort) _memoryAddress] = Convert.ToByte(txtBox.Text, 2);
                }
                catch (Exception err)
                {
                    MessageBox.Show("That's an invalid binary string!");
                    UpdateCell();
                }
            }
        }
    }
}
