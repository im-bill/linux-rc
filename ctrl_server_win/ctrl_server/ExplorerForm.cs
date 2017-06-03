using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

struct File
{
    public string filename;
    public string type;
    public string filesize;
    public string modifytime;
    public string authority;
};
struct ExplorerRes
{ 
    public string curr_path;
    public List<File> dirList;
    public List<File> regList;

};

struct Clipboard
{
    public string cmd;
    public string filename;
    public string source_path;
};
namespace ctrl_server
{


    public partial class ExplorerForm : Form
    {
        const int DIR = 1;
        const int REG = 2;
        const int LNK = 3;
        const int CHR = 4;
        const int BLK = 5;
        const int FIFO = 6;
        const int SOCK = 7;
        const int UNKOWN_TYPE = 8;

        public Socket client_socket;     

        private ExplorerRes dirScanRes;

        private string hitok = "f";
        private string cmd;
        private Clipboard clipboard;

        private bool isFirstMenu;

         public ExplorerForm()
        {
            InitializeComponent();
            ListViewSet();
            dirScanRes = new ExplorerRes();
            dirScanRes.dirList = new List<File>();
            dirScanRes.regList = new List<File>();
            dirScanRes.curr_path = string.Empty;
            listViewFile.ContextMenuStrip = contextMenuStrip2;
            contextMenuStrip1.Closed += new ToolStripDropDownClosedEventHandler(contextMenuStrip1_Closed);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void ListViewSet()
        {
            listViewFile.View = View.Details;
            listViewFile.SmallImageList = imageList1;
            listViewFile.LargeImageList = imageList1;
             listViewFile.Columns.Add("文件名");
            listViewFile.Columns.Add("大小");
            listViewFile.Columns.Add("修改日期");
            listViewFile.Columns.Add("权限");
        }

        private int getPathRes(string path)
        {
            if (path == "" || path == null)
            {
                path = "/";
            }
            string cmd;
            cmd = "EXPLORER\n" + path + "\n";
            byte [] buf = Encoding.UTF8.GetBytes(cmd);        
            client_socket.Send(buf, buf.Length, SocketFlags.None);  
            byte[] buf1 = new byte[1024 * 50];
            int len;
            //等待反馈Socket
            Form1.allDone.WaitOne();            
            Socket res_client = Form1.resClientSocket;             
            if (res_client == null)
            {
                MessageBox.Show("反馈出错");
                return -1;
            }  
            
            len = res_client.Receive(buf1, buf1.Length, SocketFlags.None);
            Form1.resClientSocket = null; 
            Form1.allDone.Reset();
            
            string tmpStr = Encoding.UTF8.GetString(buf1, 0, len);
            int pos1 = tmpStr.IndexOf("\r\n");
            int pos2;
            string flag = tmpStr.Substring(0, pos1);
            tmpStr = tmpStr.Substring(pos1 + 2);
            if (flag != "SUCCESS")
            {
                pos1 = tmpStr.IndexOf("\r\n");
                string errorcode = tmpStr.Substring(0, pos1);
                if (errorcode == "101") 
                {
                    //文件不存在
                    res_client.Close();                 
                    return 1;
                } else if (errorcode == "201")
                {
                    res_client.Close();
                    return 2;

                }
                else
                {
                    res_client.Close();                   
                    return 3;
                }                   
            }
            pos1 = tmpStr.IndexOf("\r\n");
            string revPath = tmpStr.Substring(0, pos1);
            tmpStr = tmpStr.Substring(pos1 + 2);

            dirScanRes.regList.Clear();
            dirScanRes.dirList.Clear();

            File tmpFile = new File();
            string fileEntry ;
            do
            {
                while (tmpStr.Length > 2)
                {
                   
                    pos1 = tmpStr.IndexOf("\r\n");
                    fileEntry = tmpStr.Substring(0, pos1);

                    //filename
                    pos2 = fileEntry.IndexOf('\n');
                    tmpFile.filename = fileEntry.Substring(0, pos2);
                    fileEntry = fileEntry.Substring(pos2 + 1);
                    //filetype
                    pos2 = fileEntry.IndexOf('\n');
                    tmpFile.type = fileEntry.Substring(0, pos2);
                    fileEntry = fileEntry.Substring(pos2 + 1);
                    //filesize
                    pos2 = fileEntry.IndexOf('\n');
                    tmpFile.filesize = fileEntry.Substring(0, pos2);
                    fileEntry = fileEntry.Substring(pos2 + 1);
                    //authority
                    pos2 = fileEntry.IndexOf('\n');
                    tmpFile.authority = fileEntry.Substring(0, pos2);
                    fileEntry = fileEntry.Substring(pos2 + 1);
                    //createtime
                    pos2 = fileEntry.IndexOf('\n');
                    tmpFile.modifytime = fileEntry.Substring(0, pos2);

                    tmpStr = tmpStr.Substring(pos1 + 2);

                    if (tmpFile.type == DIR.ToString())
                    {
                        dirScanRes.dirList.Add(tmpFile);
                    }
                    else
                    {
                        dirScanRes.regList.Add(tmpFile);
                    } 
                }
                len = res_client.Receive(buf1, buf1.Length, SocketFlags.None);
                tmpStr = Encoding.UTF8.GetString(buf1, 0, len);
            } while (len > 0);
            dirScanRes.curr_path = revPath;
            res_client.Close();      
            return 0;
        }

        private void refreshListview()
        {
            listViewFile.BeginUpdate();
            listViewFile.Items.Clear();

            int i = 0;
            for (i = 0; i <  dirScanRes.dirList.Count; ++i)
            {
                listViewFile.Items.Add(i.ToString(), dirScanRes.dirList[i].filename, 0);
                listViewFile.Items[i.ToString()].SubItems.Add(dirScanRes.dirList[i].filesize);
                listViewFile.Items[i.ToString()].SubItems.Add(dirScanRes.dirList[i].modifytime);
                listViewFile.Items[i.ToString()].SubItems.Add(dirScanRes.dirList[i].authority);
            }
            int j = 0;
            for (j = 0; j < dirScanRes.regList.Count; ++j )
            {
                listViewFile.Items.Add((i + j).ToString(), dirScanRes.regList[j].filename, 1);
                listViewFile.Items[(i + j).ToString()].SubItems.Add(dirScanRes.regList[j].filesize);
                listViewFile.Items[(i + j).ToString()].SubItems.Add(dirScanRes.regList[j].modifytime);
                listViewFile.Items[(i + j).ToString()].SubItems.Add(dirScanRes.regList[j].authority);
            }

            listViewFile.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入路径");
            }
            int res = getPathRes(textBox1.Text);
            if (res == 1)
            {
                MessageBox.Show("文件不存在");
                return;
            }
            else if (res == 2)
            {
                MessageBox.Show("不是文件夹");
                return;
            }
            else if (res == 3)
            {
                MessageBox.Show("可能文件不可读取");
                return;
            }
            if (res != 0)
            {
                return;
            }
            textBox1.Text = dirScanRes.curr_path;
            refreshListview();
        }

        private void ExplorerForm_Load(object sender, EventArgs e)
        {

            if (client_socket == null)
            {
                MessageBox.Show("Client Socket is nulll");
                this.Close();
                return;
            }

        }
        private void ExplorerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ExplorerForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.hitok = "f";
        }

        private void listViewFile_ItemActivate(object sender, EventArgs e)
        {
            this.hitok = "t";
        }

        private int getFileTye(string fileName)
        {
            for (int i = 0; i < dirScanRes.dirList.Count; ++i)
            {
                if (dirScanRes.dirList[i].filename == fileName)
                {
                    return int.Parse(dirScanRes.dirList[i].type);
                }
            }
            for (int i = 0; i < dirScanRes.regList.Count; ++i)
            {
                if (dirScanRes.regList[i].filename == fileName)
                {
                    return int.Parse(dirScanRes.regList[i].type);
                }
            }   
                
           return -1;
        }
        private void listViewFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.hitok == "t")
            {
                string filename = listViewFile.SelectedItems[0].Text;
                if (getFileTye(filename) == DIR)
                {
                    string path;
                    if (dirScanRes.curr_path == "/")
                    {
                        path = dirScanRes.curr_path + filename;
                    }
                    else
                    {
                        path = dirScanRes.curr_path + "/" + filename;
                    }
                    int res = getPathRes(path);
                    if (res == 1)
                    {
                        MessageBox.Show("文件不存在");
                        return;
                    }
                    else if (res == 2)
                    {
                        MessageBox.Show("不是文件夹");
                        return;
                    }
                    else if (res == 3)
                    {
                        MessageBox.Show("文件不可读取");
                        return;
                    }
                    refreshListview();
                    textBox1.Text = dirScanRes.curr_path;

                
                }
            }
        }

        private void listViewFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                
                if (listViewFile.SelectedItems.Count == 1)
                {
                    listViewFile.ContextMenuStrip = null;
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = listViewFile.SelectedItems[0].Text;
            int filetype;
            string path;

            if ((filetype = getFileTye(filename)) < 0)
            {
                MessageBox.Show("文件名无效");
                return;
            }       
            
            if (dirScanRes.curr_path == "/")
            {
                path = dirScanRes.curr_path + filename;
            }
            else
            {
                path = dirScanRes.curr_path + "/" + filename;
            }          
            
            cmd = "CMDSHELL\nrm  -rf " + path + "\n";
            byte[] buf = Encoding.UTF8.GetBytes(cmd);
            client_socket.Send(buf, buf.Length, SocketFlags.None);

            Form1.allDone.WaitOne();//等待反馈
            Socket res_client = Form1.resClientSocket;
            Form1.resClientSocket = null;
            Form1.allDone.Reset();
            if (res_client == null)
            {
                MessageBox.Show("反馈出错");
                return;
            }
            int len;
            buf = new byte[1024];
            len = res_client.Receive(buf, buf.Length, SocketFlags.None);
            string res = Encoding.UTF8.GetString(buf, 0, len);
            if (res == "CMDSHELL:SUCCESS\n")
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            res_client.Close();
        
            Thread.Sleep(1);
            int ires = getPathRes(dirScanRes.curr_path);           
            refreshListview();
            textBox1.Text = dirScanRes.curr_path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileName filenameForm = new FileName();
            string sourceFilename = null;
            string UploadPath = null;
            FileStream fs = null;
            FileInfo fileinfo = null;

            this.openFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
           
           
            openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceFilename = this.openFileDialog1.FileName;              
            }
            else
            {
                return;
            }

            filenameForm.fileName =  System.IO.Path.GetFileName(sourceFilename);
            if (filenameForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UploadPath = textBox1.Text + "/" + filenameForm.fileName;
            }
            else
            {
                return;
            }
            try
            {
                fileinfo = new FileInfo(sourceFilename);
                string cmd = "";
                cmd += "UPLOAD\n";
                cmd += UploadPath + "\n";
                cmd += fileinfo.Length.ToString() + "\n";
                byte[] buf = Encoding.ASCII.GetBytes(cmd);
                fs = new FileStream(sourceFilename, FileMode.Open);
                client_socket.Send(buf, buf.Length, SocketFlags.None); //发命令
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                fs.Close();
                return;
            }

            Form1.allDone.WaitOne();//等待完成
            Socket res_client = Form1.resClientSocket;
            Form1.resClientSocket = null;
            Form1.allDone.Reset();

            if (res_client == null)
            {
                MessageBox.Show("反馈出错");
                return;
            }

            byte[] buf1 = new byte[1024];
            int len;
            len = res_client.Receive(buf1, buf1.Length, SocketFlags.None);
            string tmpstr;
            tmpstr = Encoding.ASCII.GetString(buf1, 0, len);
            if (tmpstr != "SUCCESS")
            {
                MessageBox.Show("客户端文件创建失败");
                res_client.Close();
                res_client = null;
                return;
            }

            fs.Position = 0;
            while (true)
            {
                len = fs.Read(buf1, 0, buf1.Length);

                res_client.Send(buf1, len, SocketFlags.None);
                if (fs.Position >= fileinfo.Length - 1)
                {
                    break;
                }
            }
            fs.Close();
            fs = null;
            res_client.Close(); 
            MessageBox.Show("上传完成");
            getPathRes(dirScanRes.curr_path);
            refreshListview();           
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = listViewFile.SelectedItems[0].Text;
            
            string downloadPath = null;
            string savePath = null;
            FileStream fs = null;
            if (filename == "." || filename == "..")
            {
                MessageBox.Show("文件不可下载。。");
                return;
            }        
         
            if (dirScanRes.curr_path == "/")
            {
                downloadPath = dirScanRes.curr_path + filename;
            }
            else
            {
                downloadPath = dirScanRes.curr_path + "/" + filename;
            }

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                savePath = saveFileDialog1.FileName;
            }
            else
            {
                return ;
            }

            string cmd = "";
            cmd += "DOWNLOAD\n";
            cmd += downloadPath+ "\n";
            byte[] buf = Encoding.UTF8.GetBytes(cmd);
            client_socket.Send(buf, buf.Length, SocketFlags.None);//发送命令

            Form1.allDone.WaitOne();

            Socket res_client = Form1.resClientSocket;
            Form1.resClientSocket = null;
            Form1.allDone.Reset();
            if (res_client == null)
            {
                MessageBox.Show("反馈出错");
                return;
            }
            int len;
            buf = new byte[1024];
            len = res_client.Receive(buf, 0, 1024, SocketFlags.None);
            string tmpstr = Encoding.ASCII.GetString(buf, 0, len);

            int pos = tmpstr.IndexOf('\n');
            string flag = tmpstr.Substring(0, pos);
            if (flag != "SUCCESS")
            {
                res_client.Close();
                res_client = null;          
                return;
            }
            tmpstr = tmpstr.Substring(pos + 1);
            pos = tmpstr.IndexOf('\n');
            string lengStr = tmpstr.Substring(0, pos);

            int filesize = int.Parse(lengStr);
            try
            {
                fs = new FileStream(savePath, FileMode.Create);
            }
            catch (Exception ex)
            {
                res_client.Send(Encoding.ASCII.GetBytes("FAILURE"));
                MessageBox.Show(ex.Message);

                return;
            }
            res_client.Send(Encoding.ASCII.GetBytes("SUCCESS"));
            int total = 0;

            while ((len = res_client.Receive(buf, buf.Length, SocketFlags.None)) > 0)
            {
                fs.Write(buf, 0, len);
                total += len;
                if (total >= filesize)
                {
                    break;
                }
            }
            fs.Close();
            fs = null;
            res_client.Close();      
            MessageBox.Show("下载成功");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            string filename = listViewFile.SelectedItems[0].Text;
            int filetype;

            if (filename == "." || filename == "..")
            {
                contextMenuStrip1.Enabled = false;
                return;
            }
            else
            {
                contextMenuStrip1.Enabled = true;
            }

            if ((filetype = getFileTye(filename)) < 0)
            {
                contextMenuStrip1.Enabled = false;
                return;
            }
            else
            {
                contextMenuStrip1.Enabled = true;
            }

            if (filetype == REG)
            {
                downloadToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
            }
            else
            {
                downloadToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = listViewFile.SelectedItems[0].Text;
            string rename_FileName;
            int filetype;
            string path;
            Rename renameForm = new Rename();

            if ((filetype = getFileTye(filename)) < 0)
            {
                MessageBox.Show("文件名无效");
                return;
            }        

            if (dirScanRes.curr_path == "/")
            {
                path = dirScanRes.curr_path + filename;
            }
            else
            {
                path = dirScanRes.curr_path + "/" + filename;
            }

            renameForm.filename = filename;
            if (renameForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rename_FileName = renameForm.filename;
                rename_FileName = dirScanRes.curr_path + "/" + rename_FileName;
            }
            else
            {
                return;
            }
            
            cmd = "CMDSHELL\nmv " + path + " " + rename_FileName + "\n";
            if (sendCmd(cmd) == false)
                return;
            int ires = getPathRes(dirScanRes.curr_path);
            
            refreshListview();
            textBox1.Text = dirScanRes.curr_path;
        }

        private void mtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cmd = "CMDSHELL\n";
            if (clipboard.cmd == "COPY")
            {
                cmd += "cp " + clipboard.source_path + "/" + clipboard.filename +
                       " " + dirScanRes.curr_path + "/" + clipboard.filename +"\n";
            }
            if (clipboard.cmd == "MOVE")
            {
                cmd += "mv " + clipboard.source_path + "/" + clipboard.filename +
                          " " + dirScanRes.curr_path + "/" + clipboard.filename+"\n";
            }
            if (sendCmd(cmd) == false)
                return;
            int ires = getPathRes(dirScanRes.curr_path);

            refreshListview();
            textBox1.Text = dirScanRes.curr_path;
            clipboard.cmd = null;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.clipboard.filename = listViewFile.SelectedItems[0].Text;
            this.clipboard.source_path = dirScanRes.curr_path;
            this.clipboard.cmd = "COPY";
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (clipboard.cmd == "COPY" || clipboard.cmd == "MOVE")
            {
                contextMenuStrip2.Enabled = true;
            }
            else
            {
                contextMenuStrip2.Enabled = false;
            }
           
        }

        private void listViewFile_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            listViewFile.ContextMenuStrip = contextMenuStrip2;
        }
        private bool sendCmd(string cmd)
        {
            byte[] buf = Encoding.UTF8.GetBytes(cmd);
            client_socket.Send(buf, buf.Length, SocketFlags.None);

            Form1.allDone.WaitOne();//等待反馈
            Socket res_client = Form1.resClientSocket;
            Form1.resClientSocket = null;
            Form1.allDone.Reset();

            if (res_client == null)
            {
                MessageBox.Show("反馈出错");
                return false;
            }
            int len;
            buf = new byte[1024];
            len = res_client.Receive(buf, buf.Length, SocketFlags.None);
            string res = Encoding.UTF8.GetString(buf, 0, len);

            res_client.Close();

            if (res == "CMDSHELL:SUCCESS\n")
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("操作失败");
                return false;
            }     
            return true;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.clipboard.filename = listViewFile.SelectedItems[0].Text;
            this.clipboard.source_path = dirScanRes.curr_path;
            this.clipboard.cmd = "MOVE";
        }

    }
}

