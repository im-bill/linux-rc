using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ctrl_server
{
    public partial class Upload : Form
    {
        public Socket client_socket;
        private FileStream fs;
        private  FileInfo fileinfo;



        public Upload()
        {
            InitializeComponent();
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileName = this.openFileDialog1.FileName;
                // 你的 处理文件路径代码 
                txtSoucePath.Text = FileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
           
            if (txtSoucePath.Text == "")
            {
                MessageBox.Show("Open a file for upload.....");
                return;
            }
            if (txtTargetPath.Text == "")
            {
                MessageBox.Show("Enter the target path");
                return;
            }
            
            try
            {
                fileinfo = new FileInfo(txtSoucePath.Text);
                string cmd = "";
                cmd += "UPLOAD\n";
                cmd += txtTargetPath.Text + "\n";
                cmd += fileinfo.Length.ToString() + "\n";
                byte[] buf = Encoding.ASCII.GetBytes(cmd);
                fs = new FileStream(txtSoucePath.Text, FileMode.Open);
                client_socket.Send(buf, buf.Length, SocketFlags.None); //发命令
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }      
            
            Form1.allDone.WaitOne();//等待完成
            Socket res_client = Form1.resClientSocket;
            Form1.resClientSocket = null;
            Form1.allDone.Reset();
            ///////////////
            if (res_client == null)
            {
                MessageBox.Show("反馈错误");
                return;
            }
            ////////////
            byte [] buf1 = new byte[1024];
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
        }

        private void Upload_Load(object sender, EventArgs e)
        {
   
            if (client_socket == null)
            {
                MessageBox.Show("Client Socket is nulll");
                this.Close();
                return;
            }
    
          
        }

       

        private void Upload_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

     
    }
}
