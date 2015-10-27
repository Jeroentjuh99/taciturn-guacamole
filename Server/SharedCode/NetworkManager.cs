using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SharedCode
{
    public class NetworkManager
    {
        private readonly NetworkStream stream;

        public NetworkManager(NetworkStream stream)
        {
            this.stream = stream;
        }

        public void SendMessage(string message)
        {
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(stream, message);
        }

        public string ReceiveMessage()
        {
            BinaryFormatter f = new BinaryFormatter();
            return (string)f.Deserialize(stream);
        }
    }
}
