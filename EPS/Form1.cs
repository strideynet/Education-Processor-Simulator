using System.Diagnostics;
using System.Windows.Forms;

namespace EPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var proc = new Processor();

            while (true)
            {
                Debug.WriteLine("Cycle start");
                proc.Clock();     
            }
        }
    }
}
