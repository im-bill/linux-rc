namespace ctrl_server
{
    partial class ExplorerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
            this.btnJump = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyFiletTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(524, 12);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(75, 23);
            this.btnJump.TabIndex = 0;
            this.btnJump.Text = "跳转";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(615, 12);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(440, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "/";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "路径：";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(33, 52);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(169, 432);
            this.treeView1.TabIndex = 5;
            // 
            // listViewFile
            // 
            this.listViewFile.Location = new System.Drawing.Point(217, 52);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(550, 432);
            this.listViewFile.TabIndex = 6;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.ItemActivate += new System.EventHandler(this.listViewFile_ItemActivate);
            this.listViewFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewFile_MouseClick);
            this.listViewFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewFile_MouseDoubleClick);
            this.listViewFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewFile_MouseDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "11.png");
            this.imageList1.Images.SetKeyName(1, "22.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.modifyFiletTimeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 158);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // modifyFiletTimeToolStripMenuItem
            // 
            this.modifyFiletTimeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtimeToolStripMenuItem,
            this.atimeToolStripMenuItem,
            this.ctimeToolStripMenuItem});
            this.modifyFiletTimeToolStripMenuItem.Name = "modifyFiletTimeToolStripMenuItem";
            this.modifyFiletTimeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.modifyFiletTimeToolStripMenuItem.Text = "Modify FiletTime";
            // 
            // mtimeToolStripMenuItem
            // 
            this.mtimeToolStripMenuItem.Name = "mtimeToolStripMenuItem";
            this.mtimeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.mtimeToolStripMenuItem.Text = "mtime";
            this.mtimeToolStripMenuItem.Click += new System.EventHandler(this.mtimeToolStripMenuItem_Click);
            // 
            // atimeToolStripMenuItem
            // 
            this.atimeToolStripMenuItem.Name = "atimeToolStripMenuItem";
            this.atimeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.atimeToolStripMenuItem.Text = "atime";
            // 
            // ctimeToolStripMenuItem
            // 
            this.ctimeToolStripMenuItem.Name = "ctimeToolStripMenuItem";
            this.ctimeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ctimeToolStripMenuItem.Text = "ctime";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // ExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 507);
            this.Controls.Add(this.listViewFile);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnJump);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExplorerForm";
            this.Text = "ExplorerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExplorerForm_FormClosing);
            this.Load += new System.EventHandler(this.ExplorerForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExplorerForm_MouseDown);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyFiletTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctimeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    }
}