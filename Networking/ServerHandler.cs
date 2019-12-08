﻿using SEP3_TIER2_API.APIHandler;
using SEP3_TIER2_API.Model;
using SEP3_TIER2_Client.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using SEP3_TIER2_API.DTOFormatter;
using System.Diagnostics;

namespace SEP3_TIER2_API.Networking
{
    public class ServerHandler
    {
        public TcpClient client;
        public List<PlaneDTO> planes;
        public APIContext context;

        public ServerHandler(TcpClient client, APIContext context)
        {
            this.client = client;
            this.context = context;
            //Post();
        }
        private void SendRequest(NetworkStream stream)
        {
            Request request = new Request { Type = "REQUESTPLANES" };
            var json = JsonSerializer.Serialize(request);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }

        private Request ReceiveRequest(NetworkStream stream)
        {
            byte[] receiveLengthBytes = new byte[4];
            stream.Read(receiveLengthBytes);
            int receiveLength = BitConverter.ToInt32(receiveLengthBytes, 0);
            byte[] receiveBytes = new byte[receiveLength];
            stream.Read(receiveBytes);
            String rcv = Encoding.ASCII.GetString(receiveBytes);
            return JsonSerializer.Deserialize<Request>(rcv);
        }

        public void Run()
        {
            try
            {
                NetworkStream stream = client.GetStream();
                APIFeedHandler handler = new APIFeedHandler();
                SendRequest(stream);
                while (true)
                {
                    Request request = ReceiveRequest(stream);
                    if (request.Type.Equals("RESPONSEPLANES"))
                    {
                        planes = DTOFormatter.DTOFormatter.FormatPlanes(request.Planes);
                        foreach (PlaneDTO plane in planes)
                        {
                            context.Add(plane);
                        }
                        context.SaveChanges();
                    }
                }
            }
            catch(ObjectDisposedException ex)
            {
    
            }
        }
        /*public async void Post()
        {
            APIFeedHandler handler = new APIFeedHandler();
            foreach (PlaneDTO plane in planes)
            {
                Console.WriteLine("%%%%%%%%%%%%");
                await handler.FeedAPI(plane);
            }
        }*/
    }
    public class Request
    {
        public string Type { get; set; }
        public List<Plane> Planes { get; set; }
    }
}
