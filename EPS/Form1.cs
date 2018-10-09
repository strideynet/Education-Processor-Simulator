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
                proc.Clock();     
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }
    }
}
