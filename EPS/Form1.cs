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

            memoryBankControls.Setup(memoryBank);
            memoryBank.Setup(proc.MemoryBank);
        }

        private void ProcOnUpdateUI()
        {
            lblPC.Text = BitConverter.ToInt16(proc.PC.Value, 0).ToString();
            lblCIR.Text = BitConverter.ToInt32(proc.CIR.Value, 0).ToString();
            lblMAR.Text = BitConverter.ToInt16(proc.MAR.Value, 0).ToString();
            lblMDR.Text = BitConverter.ToInt16(proc.MDR.Value, 0).ToString();
            lblACC.Text = BitConverter.ToInt16(proc.ACC.Value, 0).ToString();

            lblR0.Text = BitConverter.ToInt16(proc.RegisterBank[0].Value, 0).ToString();
            lblR1.Text = BitConverter.ToInt16(proc.RegisterBank[1].Value, 0).ToString();
            lblR2.Text = BitConverter.ToInt16(proc.RegisterBank[2].Value, 0).ToString();
            lblR3.Text = BitConverter.ToInt16(proc.RegisterBank[3].Value, 0).ToString();
            lblR4.Text = BitConverter.ToInt16(proc.RegisterBank[4].Value, 0).ToString();
            lblR5.Text = BitConverter.ToInt16(proc.RegisterBank[5].Value, 0).ToString();
            lblR6.Text = BitConverter.ToInt16(proc.RegisterBank[6].Value, 0).ToString();
            lblR7.Text = BitConverter.ToInt16(proc.RegisterBank[7].Value, 0).ToString();
 
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
    }
}
