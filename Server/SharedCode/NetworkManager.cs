using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharedCode
{
    public class NetworkManager
    {
        private readonly NetworkStream _stream;

        public NetworkManager()
        {
            
        }

        public NetworkManager(NetworkStream stream)
        {
            this._stream = stream;
        }

        public void SendMessage(string message)
        {
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(_stream, message);
        }

        public string ReceiveMessage()
        {
            BinaryFormatter f = new BinaryFormatter();
            try
            {
                return (string) f.Deserialize(_stream);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public NetworkStream GetStream() => _stream;
    }
}
