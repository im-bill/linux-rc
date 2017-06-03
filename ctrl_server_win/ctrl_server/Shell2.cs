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
    public partial class Shell2 : Form
    {
        public Socket clientSocket;
        private Socket res_client;

        private delegate void recvResDelegate(object param);
        void rtxtContentAppend(object obj)
        {
            string content = (string)obj;
            rtxtContent.Text += content.ToString();
            // 让光标定位到文本框末尾
            rtxtContent.Select(rtxtContent.TextLength, 0);

            //然后移动滚动条，使输入点(text entry point)(即光标所在的位置）显示出来
            //这样也可以达到滚动到最下方的目的
            rtxtContent.ScrollToCaret();
        }

        public Shell2()
        {
            InitializeComponent();
        }

        

        private void Shell2_Load(object sender, EventArgs e)
        {
            btnExecuteCmd.Enabled = false;
            txtcmd.Enabled = false;
            rtxtContent.Text = "";
        }

        private void btnStartShell_Click(object sender, EventArgs e)
        {
            if (btnStartShell.Text == "Start")
            {
                if (clientSocket == null)
                {
                    MessageBox.Show("客户Socket为空！！！");
                    return;
                }
                rtxtContent.Text = "";
                string cmd = "SHELL2\n";
                clientSocket.Send(Encoding.UTF8.GetBytes(cmd));

                Form1.allDone.WaitOne();
                res_client = Form1.resClientSocket;
                Form1.resClientSocket = null;
                Form1.allDone.Reset();
                if (res_client == null)
                {
                    MessageBox.Show("接收反馈出错");
                    return;
                }
                StateObject state = new StateObject();
                state.workSocket = res_client;
                res_client.BeginReceive(state.buffer, 0, state.buffer.Length,
                    0,new AsyncCallback(OnReceive), state);
                btnStartShell.Text = "Stop";
                btnExecuteCmd.Enabled = true;
                txtcmd.Enabled = true;
            }
            else if (btnStartShell.Text == "Stop")
            {
                res_client.Close();
                res_client = null;
                btnExecuteCmd.Enabled = false;
                btnStartShell.Text = "Start";
                txtcmd.Enabled = false;
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            String content = String.Empty;
            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            // Read data from the client socket.
            try
            {
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There    might be more data, so store the data received so far.
                    state.sb.Append(Encoding.UTF8.GetString(
                    state.buffer, 0, bytesRead));
                    // Check for end-of-file tag. If it is not there, read
                    // more data.
                    content = state.sb.ToString();
                    StateObject state2 = new StateObject();
                    state2.workSocket = handler;
                    
                    rtxtContent.BeginInvoke(new recvResDelegate(rtxtContentAppend), content);
                    handler.BeginReceive(state2.buffer, 0, state2.buffer.Length,
                        0, new AsyncCallback(OnReceive), state2);
                }
                else
                {

                   
                }
            }
            catch
            {

            }
        }
        private void btnExecuteCmd_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buf = Encoding.UTF8.GetBytes(txtcmd.Text + "\n");
                rtxtContent.Text += "$" + txtcmd.Text + "\r\n";
                res_client.Send(buf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtcmd.Text = "";
           
        }

        private void Shell2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (res_client != null)
            {
                res_client.Close();
            }

        }

        private void txtcmd_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnExecuteCmd_Click(sender, e);
            }
        }
    }
}
