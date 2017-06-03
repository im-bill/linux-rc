using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ctrl_server
{
    class Common
    {
        public static bool IsSocketConnected(Socket client)
        {
            bool blockingState = client.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                client.Blocking = false;
                client.Send(tmp, 0, 0);
                return false;
            }
            catch (SocketException e)
            {
                // 产生 10035 == WSAEWOULDBLOCK 错误，说明被阻止了，但是还是连接的
                if (e.NativeErrorCode.Equals(10035))
                    return false;
                else
                    return true;
            }
            finally
            {
                client.Blocking = blockingState;    // 恢复状态
            }
        }

    }
}
