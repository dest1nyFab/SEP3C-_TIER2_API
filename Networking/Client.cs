using SEP3_TIER2_API.Context;
using SEP3_TIER2_API.Model;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;

namespace SEP3_TIER2_API.Networking
{
    public class Client
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public void SetupClient(APIContext context)
        {
            Debug.WriteLine("Starting client");
            TcpClient client = new TcpClient(Ip, Port);
            ServerHandler handler = new ServerHandler(client, context);
            Thread thread = new Thread(new ThreadStart(handler.Run));
            thread.Start();
        }
    }
}
