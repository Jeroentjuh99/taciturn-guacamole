using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharedCode
{
    public class MessageSend
    {
        public void Send(NetworkStream stream, Packet packet)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, packet);
        }
    }
}