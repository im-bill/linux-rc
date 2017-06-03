namespace ctrl_server
{
    partial class Shell2
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
            this.btnStartShell = new System.Windows.Forms.Button();
            this.rtxtContent = new System.Windows.Forms.RichTextBox();
            this.btnExecuteCmd = new System.Windows.Forms.Button();
            this.txtcmd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartShell
            // 
            this.btnStartShell.Location = new System.Drawing.Point(811, 12);
            this.btnStartShell.Name = "btnStartShell";
            this.btnStartShell.Size = new System.Drawing.Size(75, 23);
            this.btnStartShell.TabIndex = 0;
            this.btnStartShell.Text = "Start";
            this.btnStartShell.UseVisualStyleBackColor = true;
            this.btnStartShell.Click += new System.EventHandler(this.btnStartShell_Click);
            // 
            // rtxtContent
            // 
            this.rtxtContent.Location = new System.Drawing.Point(12, 41);
            this.rtxtContent.Name = "rtxtContent";
            this.rtxtContent.ReadOnly = true;
            this.rtxtContent.Size = new System.Drawing.Size(883, 456);
            this.rtxtContent.TabIndex = 1;
            this.rtxtContent.Text = "";
            // 
            // btnExecuteCmd
            // 
            this.btnExecuteCmd.Enabled = false;
            this.btnExecuteCmd.Location = new System.Drawing.Point(811, 512);
            this.btnExecuteCmd.Name = "btnExecuteCmd";
            this.btnExecuteCmd.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteCmd.TabIndex = 2;
            this.btnExecuteCmd.Text = "Execute";
            this.btnExecuteCmd.UseVisualStyleBackColor = true;
            this.btnExecuteCmd.Click += new System.EventHandler(this.btnExecuteCmd_Click);
            // 
            // txtcmd
            // 
            this.txtcmd.Location = new System.Drawing.Point(12, 512);
            this.txtcmd.Name = "txtcmd";
            this.txtcmd.Size = new System.Drawing.Size(777, 21);
            this.txtcmd.TabIndex = 3;
            this.txtcmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcmd_KeyDown);
            // 
            // Shell2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 547);
            this.Controls.Add(this.txtcmd);
            this.Controls.Add(this.btnExecuteCmd);
            this.Controls.Add(this.rtxtContent);
            this.Controls.Add(this.btnStartShell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Shell2";
            this.Text = "Shell2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shell2_FormClosing);
            this.Load += new System.EventHandler(this.Shell2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartShell;
        private System.Windows.Forms.RichTextBox rtxtContent;
        private System.Windows.Forms.Button btnExecuteCmd;
        private System.Windows.Forms.TextBox txtcmd;
    }
}