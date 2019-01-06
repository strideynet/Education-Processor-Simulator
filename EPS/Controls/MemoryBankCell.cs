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
    public partial class MemoryBankCell : UserControl
    {
        public MemoryBankCell()
        {
            InitializeComponent();
        }

        public void Setup(Int32 memoryAddress)
        {
            string memoryAddressString = Convert.ToString(memoryAddress, 2).PadLeft(3, '0');
            lblAddress.Text = "Address " + memoryAddressString.Substring(memoryAddressString.Length - 3);
        }
    }
}
