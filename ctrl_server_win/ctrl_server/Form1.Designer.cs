namespace ctrl_server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Other = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxConnection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResPort = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Offline_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdshellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shell2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backdoorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtNo,
            this.ID,
            this.IP,
            this.Other});
            this.dataGridView1.Location = new System.Drawing.Point(42, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(520, 173);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // txtNo
            // 
            this.txtNo.Frozen = true;
            this.txtNo.HeaderText = "序号";
            this.txtNo.Name = "txtNo";
            this.txtNo.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.Frozen = true;
            this.IP.HeaderText = "IP地址";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // Other
            // 
            this.Other.Frozen = true;
            this.Other.HeaderText = "其他信息";
            this.Other.Name = "Other";
            this.Other.ReadOnly = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(404, 226);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(497, 226);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(83, 206);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 21);
            this.txtServerPort.TabIndex = 3;
            this.txtServerPort.Text = "8080";
            this.txtServerPort.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务端口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "最大连接数：";
            // 
            // txtMaxConnection
            // 
            this.txtMaxConnection.Location = new System.Drawing.Point(83, 233);
            this.txtMaxConnection.Name = "txtMaxConnection";
            this.txtMaxConnection.Size = new System.Drawing.Size(100, 21);
            this.txtMaxConnection.TabIndex = 6;
            this.txtMaxConnection.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "反馈端口：";
            // 
            // txtResPort
            // 
            this.txtResPort.Location = new System.Drawing.Point(276, 206);
            this.txtResPort.Name = "txtResPort";
            this.txtResPort.Size = new System.Drawing.Size(100, 21);
            this.txtResPort.TabIndex = 8;
            this.txtResPort.Text = "8081";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Offline_ToolStripMenuItem,
            this.cmdshellToolStripMenuItem,
            this.shell2ToolStripMenuItem,
            this.backdoorToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.explorerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 180);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Offline_ToolStripMenuItem
            // 
            this.Offline_ToolStripMenuItem.Name = "Offline_ToolStripMenuItem";
            this.Offline_ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.Offline_ToolStripMenuItem.Text = "Offline";
            this.Offline_ToolStripMenuItem.Click += new System.EventHandler(this.Offline_ToolStripMenuItem_Click);
            // 
            // cmdshellToolStripMenuItem
            // 
            this.cmdshellToolStripMenuItem.Name = "cmdshellToolStripMenuItem";
            this.cmdshellToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.cmdshellToolStripMenuItem.Text = "Shell";
            this.cmdshellToolStripMenuItem.Click += new System.EventHandler(this.cmdshellToolStripMenuItem_Click);
            // 
            // shell2ToolStripMenuItem
            // 
            this.shell2ToolStripMenuItem.Name = "shell2ToolStripMenuItem";
            this.shell2ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.shell2ToolStripMenuItem.Text = "Shell2";
            this.shell2ToolStripMenuItem.Click += new System.EventHandler(this.shell2ToolStripMenuItem_Click);
            // 
            // backdoorToolStripMenuItem
            // 
            this.backdoorToolStripMenuItem.Name = "backdoorToolStripMenuItem";
            this.backdoorToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.backdoorToolStripMenuItem.Text = "Backdoor";
            this.backdoorToolStripMenuItem.Click += new System.EventHandler(this.backdoorToolStripMenujItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.explorerToolStripMenuItem.Text = "Explorer";
            this.explorerToolStripMenuItem.Click += new System.EventHandler(this.explorerToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 272);
            this.Controls.Add(this.txtResPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaxConnection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "控制端";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResPort;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Offline_ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Other;
        private System.Windows.Forms.ToolStripMenuItem cmdshellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backdoorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shell2ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;


    }
}

