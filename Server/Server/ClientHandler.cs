using System;
using System.Collections.Generic;
using System.IO;
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
        private TcpClient _client;
        private Server _server;
        private NetworkStream _stream;
        private NetworkManager _manager;

        public ClientHandler(TcpClient client, Server server)
        {
            this._client = client;
            this._server = server;
            this._stream = client.GetStream();
            _manager = new NetworkManager(_stream);
            Thread t = new Thread(ClientThread);
            t.IsBackground = true;
            t.Start();
        }

        public void ClientThread()
        {
            while (_client.Connected)
            {
                string a = "";
                a = _manager.ReceiveMessage();
                
                switch (a)
                {
                    case "files":
                        HandleFiles();
                        break;

                    default:
                        HandleUpdate(a.Split('/'));
                        break;
                }
            }
        }

        private void HandleUpdate(string[] message)
        {
            if (message.GetLength(0) != 2)
            {
                return;
            }

            try
            {
                string[] files = Directory.GetFiles(Path.Combine(Application.StartupPath, message[0]));
                if (message[1].Equals(files[0]))
                {
                    _manager.SendMessage("0");
                }
                else
                {
                    string b = new FileInfo(Path.Combine(Application.StartupPath, message[0], files[0])).Length.ToString();
                    _manager.SendMessage(b + '/' + files[0]);
                    _client.Client.SendFile(Path.Combine(Application.StartupPath, message[0], files[0]));
                }
            }
            catch (Exception)
            {
                _manager.SendMessage("0");
            }
        }

        private string Searchfolders()
        {
            string a = "";
            foreach (var variable in _server.ScanFolders())
            {
                a += variable.Name + '/';
            }
            return a.Substring(0, a.LastIndexOf('/'));
        }

        private void HandleFiles()
        {
            _manager.SendMessage(Searchfolders());
        }
    }
}
