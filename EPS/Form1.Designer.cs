namespace EPS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClockStep = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblClockrate = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblFetch = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblMicrocode = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblACC = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMDR = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMAR = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCIR = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtClockRate = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.btnStepPageForward = new System.Windows.Forms.Button();
            this.btnStepPageBack = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.memoryBank1 = new EPS.MemoryBank();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClockRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClockStep
            // 
            this.btnClockStep.Location = new System.Drawing.Point(12, 585);
            this.btnClockStep.Name = "btnClockStep";
            this.btnClockStep.Size = new System.Drawing.Size(196, 36);
            this.btnClockStep.TabIndex = 0;
            this.btnClockStep.Text = "Clock Step";
            this.btnClockStep.UseVisualStyleBackColor = true;
            this.btnClockStep.Click += new System.EventHandler(this.BtnCycleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 542);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblClockrate);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.lblFetch);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.lblMicrocode);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblACC);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblMDR);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblMAR);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lblCIR);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblPC);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 516);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblClockrate
            // 
            this.lblClockrate.AutoSize = true;
            this.lblClockrate.Location = new System.Drawing.Point(79, 241);
            this.lblClockrate.Name = "lblClockrate";
            this.lblClockrate.Size = new System.Drawing.Size(62, 13);
            this.lblClockrate.TabIndex = 43;
            this.lblClockrate.Text = "lblClockrate";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 241);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "Clock Rate";
            // 
            // lblFetch
            // 
            this.lblFetch.AutoSize = true;
            this.lblFetch.Location = new System.Drawing.Point(79, 228);
            this.lblFetch.Name = "lblFetch";
            this.lblFetch.Size = new System.Drawing.Size(35, 13);
            this.lblFetch.TabIndex = 41;
            this.lblFetch.Text = "label2";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 228);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "Fetch";
            // 
            // lblMicrocode
            // 
            this.lblMicrocode.AutoSize = true;
            this.lblMicrocode.Location = new System.Drawing.Point(79, 215);
            this.lblMicrocode.Name = "lblMicrocode";
            this.lblMicrocode.Size = new System.Drawing.Size(35, 13);
            this.lblMicrocode.TabIndex = 39;
            this.lblMicrocode.Text = "label2";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 215);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 13);
            this.label22.TabIndex = 38;
            this.label22.Text = "Microcode";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 202);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "Other Information";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 172);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "label18";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 172);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "R6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "R5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "label4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "R4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "label2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "R3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "label2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "R2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(40, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "label2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "R1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "General Registers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Special Registers";
            // 
            // lblACC
            // 
            this.lblACC.AutoSize = true;
            this.lblACC.Location = new System.Drawing.Point(40, 70);
            this.lblACC.Name = "lblACC";
            this.lblACC.Size = new System.Drawing.Size(38, 13);
            this.lblACC.TabIndex = 12;
            this.lblACC.Text = "lblACC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "ACC";
            // 
            // lblMDR
            // 
            this.lblMDR.AutoSize = true;
            this.lblMDR.Location = new System.Drawing.Point(40, 57);
            this.lblMDR.Name = "lblMDR";
            this.lblMDR.Size = new System.Drawing.Size(35, 13);
            this.lblMDR.TabIndex = 10;
            this.lblMDR.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "MDR";
            // 
            // lblMAR
            // 
            this.lblMAR.AutoSize = true;
            this.lblMAR.Location = new System.Drawing.Point(40, 44);
            this.lblMAR.Name = "lblMAR";
            this.lblMAR.Size = new System.Drawing.Size(35, 13);
            this.lblMAR.TabIndex = 8;
            this.lblMAR.Text = "label2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "MAR";
            // 
            // lblCIR
            // 
            this.lblCIR.AutoSize = true;
            this.lblCIR.Location = new System.Drawing.Point(40, 31);
            this.lblCIR.Name = "lblCIR";
            this.lblCIR.Size = new System.Drawing.Size(35, 13);
            this.lblCIR.TabIndex = 6;
            this.lblCIR.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CIR";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(40, 18);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(35, 13);
            this.lblPC.TabIndex = 4;
            this.lblPC.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PC";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 516);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Load Program";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtClockRate
            // 
            this.txtClockRate.Location = new System.Drawing.Point(214, 601);
            this.txtClockRate.Name = "txtClockRate";
            this.txtClockRate.Size = new System.Drawing.Size(120, 20);
            this.txtClockRate.TabIndex = 3;
            this.txtClockRate.ValueChanged += new System.EventHandler(this.txtClockRate_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(214, 585);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 13);
            this.label23.TabIndex = 4;
            this.label23.Text = "Clock Rate (CPS):";
            // 
            // btnStepPageForward
            // 
            this.btnStepPageForward.Location = new System.Drawing.Point(1209, 585);
            this.btnStepPageForward.Name = "btnStepPageForward";
            this.btnStepPageForward.Size = new System.Drawing.Size(87, 35);
            this.btnStepPageForward.TabIndex = 6;
            this.btnStepPageForward.Text = "->";
            this.btnStepPageForward.UseVisualStyleBackColor = true;
            this.btnStepPageForward.Click += new System.EventHandler(this.btnStepPageForward_Click);
            // 
            // btnStepPageBack
            // 
            this.btnStepPageBack.Location = new System.Drawing.Point(987, 585);
            this.btnStepPageBack.Name = "btnStepPageBack";
            this.btnStepPageBack.Size = new System.Drawing.Size(87, 35);
            this.btnStepPageBack.TabIndex = 7;
            this.btnStepPageBack.Text = "<-";
            this.btnStepPageBack.UseVisualStyleBackColor = true;
            this.btnStepPageBack.Click += new System.EventHandler(this.btnStepPageBack_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1090, 579);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 13);
            this.label25.TabIndex = 8;
            this.label25.Text = "Showing Addresses";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(1133, 592);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 13);
            this.label26.TabIndex = 9;
            this.label26.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(161, 565);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(89, 13);
            this.label27.TabIndex = 10;
            this.label27.Text = "Clock Controls";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(1076, 565);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(133, 13);
            this.label28.TabIndex = 11;
            this.label28.Text = "Memory Bank Controls";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(1121, 608);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(43, 13);
            this.label29.TabIndex = 12;
            this.label29.Text = "111111";
            // 
            // memoryBank1
            // 
            this.memoryBank1.Location = new System.Drawing.Point(218, 34);
            this.memoryBank1.Name = "memoryBank1";
            this.memoryBank1.Size = new System.Drawing.Size(1080, 520);
            this.memoryBank1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 633);
            this.Controls.Add(this.memoryBank1);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.btnStepPageBack);
            this.Controls.Add(this.btnStepPageForward);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtClockRate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClockStep);
            this.Name = "Form1";
            this.Text = "Educational Processor Simulator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClockRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClockStep;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMDR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMAR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCIR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblACC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblMicrocode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblFetch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown txtClockRate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblClockrate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnStepPageForward;
        private System.Windows.Forms.Button btnStepPageBack;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private MemoryBank memoryBank1;
    }
}

