using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using SharedCode;

namespace Server
{
    public class ListenerClass
    {
        private readonly Server _server;

        public ListenerClass(Server server)
        {
            this._server = server;
        }

        private string GetPublicIp()
        {
            string ip = "";
            try
            {
                string url = "http://icanhazip.com";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                ip = response;
            }
            catch (Exception)
            {
                ip = "127.0.0.1";
            }
            return ip;
        }

        

        public void StartThread()
        {
            IPAddress address = IPAddress.Parse(GetPublicIp());
            TcpListener listener = new TcpListener(IPAddress.Any, 56931);
            listener.Start();
            _server.SetLabelText(address.ToString(), "Online", Color.DarkGreen);      
            while (true)
            {
                ClientHandler client = new ClientHandler(listener.AcceptTcpClient(), _server);
            }
        }
    }
}