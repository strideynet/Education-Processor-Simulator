using System;
using System.Windows.Forms;

namespace EPS
{
    public partial class Form1 : Form
    {
        private Processor proc;
        private Timer timer;
        public Form1()
        {
            InitializeComponent();

            proc = new Processor();
            ProcOnUpdateUI();

            proc.UpdateUI += ProcOnUpdateUI;

            timer = new Timer();
            timer.Tick += (sender, args) => { btnClockStep.PerformClick(); };
        }

        private void ProcOnUpdateUI()
        {
            lblPC.Text = BitConverter.ToInt16(proc.PC.Value, 0).ToString();
            lblCIR.Text = BitConverter.ToInt16(proc.CIR.Value, 0).ToString();
            lblMAR.Text = BitConverter.ToInt16(proc.MAR.Value, 0).ToString();
            lblMDR.Text = BitConverter.ToInt16(proc.MDR.Value, 0).ToString();
            lblACC.Text = BitConverter.ToInt16(proc.ACC.Value, 0).ToString();
            lblMicrocode.Text = "filler";
            lblFetch.Text = proc.Fetching.ToString();
        }

        private void BtnCycleClick(object sender, System.EventArgs e)
        {
            proc.Clock();
        }

        private void txtClockRate_ValueChanged(object sender, EventArgs e)
        {
            lblClockrate.Text = txtClockRate.Value.ToString();

            if (txtClockRate.Value == 0)
            {
                timer.Enabled = false;

                return;
            }

            timer.Enabled = true;
            timer.Interval = (int) ((1 / txtClockRate.Value) * 1000);
        }

        private void btnStepPageForward_Click(object sender, EventArgs e)
        {
            memoryBank1.StepMemoryPage(1);
        }

        private void btnStepPageBack_Click(object sender, EventArgs e)
        {
            memoryBank1.StepMemoryPage(-1);
        }
    }
}
