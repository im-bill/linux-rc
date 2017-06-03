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

namespace ctrl_server
{
    public partial class CMDShell : Form
    {
        public Socket client_socket;

         public CMDShell()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter cmd");
                return;
            }
            if (client_socket == null)
            {
                MessageBox.Show("Socket is null");
            }
            string cmd = "";
            cmd += "CMDSHELL\n"+textBox1.Text+"\n";
            byte [] buf = Encoding.UTF8.GetBytes(cmd);
            try
            {

                client_socket.Send(buf,buf.Length, SocketFlags.None); //发送命令
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
     
            Form1.allDone.WaitOne();
            Socket res_client = Form1.resClientSocket;
            Form1.resClientSocket = null;
            Form1.allDone.Reset();
            if (res_client == null)
            {
                MessageBox.Show("接收反馈出错");
                return;
            }
         
            int len;
            buf = new byte[1024];
            while ((len = res_client.Receive(buf, 1023, SocketFlags.None)) > 0)
            {
                richTextBox1.Text += Encoding.UTF8.GetString(buf, 0, len);
            }
            res_client.Close();           
        }

        private void CMDShell_Load(object sender, EventArgs e)
        {          
            if (client_socket == null)
            {
                MessageBox.Show("Client Socket is nulll");
                this.Close();
                return;
            }
           
        }
            
           

        private void CMDShell_FormClosing(object sender, FormClosingEventArgs e)
        {
                
        }
   }
   
}


