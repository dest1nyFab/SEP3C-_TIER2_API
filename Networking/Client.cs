using SEP3_TIER2_API.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

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
