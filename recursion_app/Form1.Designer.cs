namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDepth1;
        private System.Windows.Forms.Button btnDrawA1;
        private System.Windows.Forms.Button btnDrawB1;
        private System.Windows.Forms.Panel drawPanel1;
        private System.Windows.Forms.Label lblDepth1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.txtDepth1 = new System.Windows.Forms.TextBox();
            this.btnDrawA1 = new System.Windows.Forms.Button();
            this.btnDrawB1 = new System.Windows.Forms.Button();
            this.drawPanel1 = new System.Windows.Forms.Panel();
            this.lblDepth1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDepth1
            // 
            this.txtDepth1.Location = new System.Drawing.Point(130, 10);
            this.txtDepth1.Name = "txtDepth1";
            this.txtDepth1.Size = new System.Drawing.Size(50, 20);
            this.txtDepth1.TabIndex = 1;
            // 
            // btnDrawA1
            // 
            this.btnDrawA1.Location = new System.Drawing.Point(200, 10);
            this.btnDrawA1.Name = "btnDrawA1";
            this.btnDrawA1.Size = new System.Drawing.Size(75, 23);
            this.btnDrawA1.TabIndex = 2;
            this.btnDrawA1.Text = "Zīmēt A";
            // 
            // btnDrawB1
            // 
            this.btnDrawB1.Location = new System.Drawing.Point(280, 10);
            this.btnDrawB1.Name = "btnDrawB1";
            this.btnDrawB1.Size = new System.Drawing.Size(75, 23);
            this.btnDrawB1.TabIndex = 3;
            this.btnDrawB1.Text = "Zīmēt B";
            // 
            // drawPanel1
            // 
            this.drawPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel1.Location = new System.Drawing.Point(10, 50);
            this.drawPanel1.Name = "drawPanel1";
            this.drawPanel1.Size = new System.Drawing.Size(750, 500);
            this.drawPanel1.TabIndex = 4;
            // 
            // lblDepth1
            // 
            this.lblDepth1.Location = new System.Drawing.Point(10, 10);
            this.lblDepth1.Name = "lblDepth1";
            this.lblDepth1.Size = new System.Drawing.Size(100, 23);
            this.lblDepth1.TabIndex = 0;
            this.lblDepth1.Text = "Rekursijas dziļums:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 578);
            this.Controls.Add(this.lblDepth1);
            this.Controls.Add(this.txtDepth1);
            this.Controls.Add(this.btnDrawA1);
            this.Controls.Add(this.btnDrawB1);
            this.Controls.Add(this.drawPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
