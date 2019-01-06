namespace EPS
{
    partial class MemoryBankControls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label26 = new System.Windows.Forms.Label();
            this.lblMemoryEnd = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblMemoryStart = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnStepPageBack = new System.Windows.Forms.Button();
            this.btnStepPageForward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(140, 39);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 13);
            this.label26.TabIndex = 21;
            this.label26.Text = "TO";
            // 
            // lblMemoryEnd
            // 
            this.lblMemoryEnd.AutoSize = true;
            this.lblMemoryEnd.Location = new System.Drawing.Point(102, 51);
            this.lblMemoryEnd.Name = "lblMemoryEnd";
            this.lblMemoryEnd.Size = new System.Drawing.Size(103, 13);
            this.lblMemoryEnd.TabIndex = 20;
            this.lblMemoryEnd.Text = "0000000000111111";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(91, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(133, 13);
            this.label28.TabIndex = 19;
            this.label28.Text = "Memory Bank Controls";
            // 
            // lblMemoryStart
            // 
            this.lblMemoryStart.AutoSize = true;
            this.lblMemoryStart.Location = new System.Drawing.Point(102, 26);
            this.lblMemoryStart.Name = "lblMemoryStart";
            this.lblMemoryStart.Size = new System.Drawing.Size(103, 13);
            this.lblMemoryStart.TabIndex = 18;
            this.lblMemoryStart.Text = "0000000000000000";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(103, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "Showing Addresses";
            // 
            // btnStepPageBack
            // 
            this.btnStepPageBack.Location = new System.Drawing.Point(0, 26);
            this.btnStepPageBack.Name = "btnStepPageBack";
            this.btnStepPageBack.Size = new System.Drawing.Size(87, 35);
            this.btnStepPageBack.TabIndex = 16;
            this.btnStepPageBack.Text = "<-";
            this.btnStepPageBack.UseVisualStyleBackColor = true;
            this.btnStepPageBack.Click += new System.EventHandler(this.StepBack);
            // 
            // btnStepPageForward
            // 
            this.btnStepPageForward.Location = new System.Drawing.Point(221, 26);
            this.btnStepPageForward.Name = "btnStepPageForward";
            this.btnStepPageForward.Size = new System.Drawing.Size(87, 35);
            this.btnStepPageForward.TabIndex = 15;
            this.btnStepPageForward.Text = "->";
            this.btnStepPageForward.UseVisualStyleBackColor = true;
            this.btnStepPageForward.Click += new System.EventHandler(this.StepForward);
            // 
            // MemoryBankControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblMemoryEnd);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.lblMemoryStart);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.btnStepPageBack);
            this.Controls.Add(this.btnStepPageForward);
            this.Name = "MemoryBankControls";
            this.Size = new System.Drawing.Size(309, 66);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblMemoryEnd;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblMemoryStart;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnStepPageBack;
        private System.Windows.Forms.Button btnStepPageForward;
    }
}
