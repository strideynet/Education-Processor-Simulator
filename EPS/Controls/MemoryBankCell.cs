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

        public void Setup(Int32 memoryAddress, EPS.Components.MemoryBank memory = null) // Final stage of setup.
        {
            string memoryAddressString = Convert.ToString(memoryAddress, 2).PadLeft(3, '0'); // String format val
            lblAddress.Text = "Address " + memoryAddressString.Substring(memoryAddressString.Length - 3); // Ensure length is correct

            _memory = memory ?? _memory; // Handle memory being null.
            _memoryAddress = memoryAddress;

            UpdateCell();
        }

        public void UpdateCell()
        {
            if (!(_memory is null))
            {
                txtBox.Text = Convert.ToString(_memory[(ushort)_memoryAddress], 2).PadLeft(8, '0'); // String format to 8 bits.
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            // Provide binary value validation
            if (txtBox.Text.Length > 0)
            {
                try
                {
                    _memory[(ushort) _memoryAddress] = Convert.ToByte(txtBox.Text, 2); // Update value
                }
                catch (Exception err) // Convert throws exception if it cannot cast.
                {
                    MessageBox.Show("That's an invalid binary string!"); // Inform user.
                    UpdateCell(); // Reset to prev value
                }
            }
        }
    }
}
