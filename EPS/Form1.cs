﻿using System.Windows.Forms;

namespace EPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var proc = new Processor.Processor();

            while (true)
            {
                proc.Cycle();
            }
        }
    }
}
