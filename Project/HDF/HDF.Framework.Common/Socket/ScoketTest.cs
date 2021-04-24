using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Common.Socket
{
    class ScoketTest
    {

        private TextBox txt_Message;






        private System.Net.Sockets.Socket _listenSocket;

        private List<System.Net.Sockets.Socket> _clientSockets = new List<System.Net.Sockets.Socket>();





        private void btn_Open_Click(object sender, EventArgs e)
        {
            _listenSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _listenSocket.Bind(new IPEndPoint(IPAddress.Any, 6666));
            _listenSocket.Listen(0);
            txt_Message.AppendText($"{DateTime.Now}:服务器开始监听。。。\r\n");

            Thread listenThread = new Thread(Accept);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            _clientSockets.ForEach(s =>
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            });

            //_listenSocket?.Shutdown(SocketShutdown.Both);
            _listenSocket?.Close();
            _listenSocket = null;

            txt_Message.AppendText($"{DateTime.Now}:服务器停止监听。。。\r\n");
        }

        private void Accept()
        {
            while (true)
            {
                try
                {
                    if (_listenSocket == null) break;

                    var socket = _listenSocket.Accept();

                    _clientSockets.Add(socket);

                    txt_Message.AppendText($"{DateTime.Now}:{socket.RemoteEndPoint}连接到服务器\r\n");

                    Thread clientThread = new Thread(HandleClient);
                    clientThread.IsBackground = true;
                    clientThread.Start(socket);
                }
                catch (Exception e)
                {
                    txt_Message.AppendText($"{DateTime.Now}:监听出现错误-{e.Message}\r\n");
                    break;
                }
            }
        }


        private void HandleClient(object socketObj)
        {
            var socket = socketObj as System.Net.Sockets.Socket;
            while (true)
            {
                try
                {
                    if (socket == null || socket.Poll(10, SelectMode.SelectRead))
                    {
                        txt_Message.AppendText($"{DateTime.Now}-{socket.RemoteEndPoint}:断开连接\r\n");
                        break;
                    }

                    byte[] readBuff = new byte[1024];
                    int count = socket.Receive(readBuff);

                    if (count == 0) continue;

                    string msg = Encoding.UTF8.GetString(readBuff, 0, count);

                    txt_Message.AppendText($"{DateTime.Now}-{socket.RemoteEndPoint}:{msg}\r\n");
                }
                catch (Exception e)
                {
                    txt_Message.AppendText($"{DateTime.Now}:连接错误-{e.Message}\r\n");
                    break;
                }
            }
            if (socket != null)
                _clientSockets.Remove(socket);
        }





    }
}
