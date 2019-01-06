namespace EPS
{
    partial class MemoryBankRow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddressEnd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddressStart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblAddressEnd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblAddressStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 65);
            this.panel1.TabIndex = 0;
            // 
            // lblAddressEnd
            // 
            this.lblAddressEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAddressEnd.AutoSize = true;
            this.lblAddressEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressEnd.Location = new System.Drawing.Point(0, 43);
            this.lblAddressEnd.Name = "lblAddressEnd";
            this.lblAddressEnd.Size = new System.Drawing.Size(119, 13);
            this.lblAddressEnd.TabIndex = 3;
            this.lblAddressEnd.Text = "0000000000000000";
            this.lblAddressEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "TO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddressStart
            // 
            this.lblAddressStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAddressStart.AutoSize = true;
            this.lblAddressStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressStart.Location = new System.Drawing.Point(0, 17);
            this.lblAddressStart.Name = "lblAddressStart";
            this.lblAddressStart.Size = new System.Drawing.Size(119, 13);
            this.lblAddressStart.TabIndex = 1;
            this.lblAddressStart.Text = "0000000000000000";
            this.lblAddressStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Addresses";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MemoryBankRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "MemoryBankRow";
            this.Size = new System.Drawing.Size(1080, 65);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddressEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAddressStart;
    }
}
