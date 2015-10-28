using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SharedCode;

namespace Server
{
    class ClientHandler
    {
        private TcpClient client;
        private Server _server;
        private NetworkStream _stream;
        private NetworkManager manager;

        public ClientHandler(TcpClient client, Server server)
        {
            this.client = client;
            this._server = server;
            this._stream = client.GetStream();
            manager = new NetworkManager(_stream);
            Thread t = new Thread(ClientThread);
            t.IsBackground = true;
            t.Start();
        }

        public void ClientThread()
        {
            while (client.Connected)
            {
                string a = manager.ReceiveMessage();
                switch (a)
                {
                    case "files":
                        HandleFiles();
                        break;

                    default:
                        break;
                }
            }
        }

        private void HandleFiles()
        {
            string a = "";
            foreach (var variable in _server.ScanFolders())
            {
                a += variable.Name + "/";
            }
            manager.SendMessage(a);
        }
    }
}
