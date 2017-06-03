namespace ctrl_server
{
    partial class DownloadForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoucePath = new System.Windows.Forms.TextBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "下载路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "保存路径";
            // 
            // txtSoucePath
            // 
            this.txtSoucePath.Location = new System.Drawing.Point(119, 32);
            this.txtSoucePath.Name = "txtSoucePath";
            this.txtSoucePath.Size = new System.Drawing.Size(226, 21);
            this.txtSoucePath.TabIndex = 2;
            this.txtSoucePath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(119, 79);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(226, 21);
            this.txtSavePath.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(391, 77);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(183, 137);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "对方计算机的文件路径";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 194);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.txtSoucePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DownloadForm";
            this.Text = "DownloadForm";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoucePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}