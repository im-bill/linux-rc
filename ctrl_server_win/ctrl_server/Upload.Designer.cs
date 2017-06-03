namespace ctrl_server
{
    partial class Upload
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtSoucePath = new System.Windows.Forms.TextBox();
            this.btnExplore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "源文件路径";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(307, 98);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtSoucePath
            // 
            this.txtSoucePath.Location = new System.Drawing.Point(83, 28);
            this.txtSoucePath.Name = "txtSoucePath";
            this.txtSoucePath.Size = new System.Drawing.Size(202, 21);
            this.txtSoucePath.TabIndex = 2;
            // 
            // btnExplore
            // 
            this.btnExplore.Location = new System.Drawing.Point(307, 26);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(75, 23);
            this.btnExplore.TabIndex = 3;
            this.btnExplore.Text = "浏览";
            this.btnExplore.UseVisualStyleBackColor = true;
            this.btnExplore.Click += new System.EventHandler(this.btnExplore_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "目标路径";
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.Location = new System.Drawing.Point(83, 57);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(202, 21);
            this.txtTargetPath.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 133);
            this.Controls.Add(this.txtTargetPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExplore);
            this.Controls.Add(this.txtSoucePath);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Upload";
            this.Text = "Upload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Upload_FormClosing);
            this.Load += new System.EventHandler(this.Upload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtSoucePath;
        private System.Windows.Forms.Button btnExplore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}