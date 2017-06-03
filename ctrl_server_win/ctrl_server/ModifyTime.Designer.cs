namespace ctrl_server
{
    partial class ModifyTime
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYY = new System.Windows.Forms.TextBox();
            this.txtMM = new System.Windows.Forms.TextBox();
            this.txtDD = new System.Windows.Forms.TextBox();
            this.txtHH = new System.Windows.Forms.TextBox();
            this.txtmin = new System.Windows.Forms.TextBox();
            this.txtsec = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "日";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "月";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = ":";
            // 
            // txtYY
            // 
            this.txtYY.AcceptsReturn = true;
            this.txtYY.Location = new System.Drawing.Point(91, 52);
            this.txtYY.MaxLength = 4;
            this.txtYY.Name = "txtYY";
            this.txtYY.Size = new System.Drawing.Size(33, 21);
            this.txtYY.TabIndex = 8;
            this.txtYY.Text = "2012";
            // 
            // txtMM
            // 
            this.txtMM.Location = new System.Drawing.Point(153, 52);
            this.txtMM.MaxLength = 2;
            this.txtMM.Name = "txtMM";
            this.txtMM.Size = new System.Drawing.Size(22, 21);
            this.txtMM.TabIndex = 9;
            this.txtMM.Text = "12";
            // 
            // txtDD
            // 
            this.txtDD.Location = new System.Drawing.Point(204, 52);
            this.txtDD.MaxLength = 2;
            this.txtDD.Name = "txtDD";
            this.txtDD.Size = new System.Drawing.Size(17, 21);
            this.txtDD.TabIndex = 10;
            this.txtDD.Text = "12";
            // 
            // txtHH
            // 
            this.txtHH.Location = new System.Drawing.Point(275, 52);
            this.txtHH.MaxLength = 2;
            this.txtHH.Name = "txtHH";
            this.txtHH.Size = new System.Drawing.Size(21, 21);
            this.txtHH.TabIndex = 11;
            this.txtHH.Text = "11";
            // 
            // txtmin
            // 
            this.txtmin.Location = new System.Drawing.Point(310, 52);
            this.txtmin.MaxLength = 2;
            this.txtmin.Name = "txtmin";
            this.txtmin.Size = new System.Drawing.Size(21, 21);
            this.txtmin.TabIndex = 12;
            this.txtmin.Text = "11";
            // 
            // txtsec
            // 
            this.txtsec.Location = new System.Drawing.Point(354, 52);
            this.txtsec.MaxLength = 2;
            this.txtsec.Name = "txtsec";
            this.txtsec.Size = new System.Drawing.Size(21, 21);
            this.txtsec.TabIndex = 13;
            this.txtsec.Text = "11";
            // 
            // ModifyTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 163);
            this.Controls.Add(this.txtsec);
            this.Controls.Add(this.txtmin);
            this.Controls.Add(this.txtHH);
            this.Controls.Add(this.txtDD);
            this.Controls.Add(this.txtMM);
            this.Controls.Add(this.txtYY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ModifyTime";
            this.ShowInTaskbar = false;
            this.Text = "ModifyTime";
            this.Load += new System.EventHandler(this.ModifyTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYY;
        private System.Windows.Forms.TextBox txtMM;
        private System.Windows.Forms.TextBox txtDD;
        private System.Windows.Forms.TextBox txtHH;
        private System.Windows.Forms.TextBox txtmin;
        private System.Windows.Forms.TextBox txtsec;
    }
}