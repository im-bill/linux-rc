using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;

namespace ctrl_server
{
    public partial class DownloadForm : Form
    {
        public Socket client_socket;

        private FileStream fs;
        private int filesize;     

        public DownloadForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter =  "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                txtSavePath.Text= saveFileDialog1.FileName;
            }
            
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
        }
               

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (txtSavePath.Text == "")
            {
                MessageBox.Show("Save path is empty!!");
                return;
            }
            if (txtSoucePath.Text == "")
            {
                MessageBox.Show("下载路径为空");
                return;
            }

            string cmd = "";
            cmd += "DOWNLOAD\n";
            cmd += txtSoucePath.Text + "\n";
            byte[] buf = Encoding.ASCII.GetBytes(cmd);
            client_socket.Send(buf, buf.Length, SocketFlags.None);          
            
            Form1.allDone.WaitOne();
            Socket res_client = Form1.resClientSocket;
            Form1.resClientSocket = null;
            Form1.allDone.Reset();
            if (res_client == null)
            {
                MessageBox.Show("反馈错误");
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
           tmpstr = tmpstr.Substring(pos+1);
           pos = tmpstr.IndexOf('\n');
           string lengStr = tmpstr.Substring(0, pos);

           filesize = int.Parse(lengStr);
           try
           {
               fs = new FileStream(txtSavePath.Text, FileMode.Create);
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
    }
}
