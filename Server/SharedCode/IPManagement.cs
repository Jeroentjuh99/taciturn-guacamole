using System;
using System.Net.Sockets;
using System.Security.Permissions;

namespace SharedCode
{
    public class IPManagement
    {
        public Tuple<string, int> ReturnIpAndPort()
        {
            return Tuple.Create(GetPublicIp(), 25681);
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
            catch (Exception e)
            {
                ip = "127.0.0.1";
            }
            return ip;
        }
    }
}