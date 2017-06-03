namespace ctrl_server
{
    partial class CMDShell
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
            this.btnCmd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnCmd
            // 
            this.btnCmd.Location = new System.Drawing.Point(373, 31);
            this.btnCmd.Name = "btnCmd";
            this.btnCmd.Size = new System.Drawing.Size(75, 23);
            this.btnCmd.TabIndex = 0;
            this.btnCmd.Text = "CMD";
            this.btnCmd.UseVisualStyleBackColor = true;
            this.btnCmd.Click += new System.EventHandler(this.btnCmd_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(38, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(365, 378);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // CMDShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 474);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCmd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CMDShell";
            this.Text = "Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMDShell_FormClosing);
            this.Load += new System.EventHandler(this.CMDShell_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCmd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}