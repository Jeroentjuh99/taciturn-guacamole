using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class ClientHandler
    {
        public TcpListener Listener;
        private List<ClientClass> clients = new List<ClientClass>();

        public ClientHandler(Tuple<string, int> IpAndPort)
        {
            IPAddress ip = IPAddress.Parse(IpAndPort.Item1);
            this.Listener = new TcpListener(ip, IpAndPort.Item2);
            Listener.Start();
            while (true)
            {
                TcpClient newClient = Listener.AcceptTcpClient();
                clients.Add(new ClientClass(newClient));
            }
        }
    }

    public class ClientClass
    {
        public ClientClass(TcpClient client)
        {
            
        }
    }
}