using Newtonsoft.Json;
using SEP3_TIER2_API.DTOFormat;
using SEP3_TIER2_API.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SEP3_TIER2_API.Networking
{
    public class ServerHandler: IServerHandler
    {
        private TcpClient client;
        private List<FlightPlanDTO> flightPlans;
        private List<PlaneDTO> planes;
        private APIContext context;
        private IDTOFormatter _formatterContext;

        public ServerHandler()
        {
            
        }

        public ServerHandler(TcpClient client, APIContext context)
        {
            this.client = client;
            this.context = context;
            _formatterContext = new DTOFormatter();
        }

        private void SendRequest(NetworkStream stream)
        {
            Request request = new Request { Type = "REQUESTPLANES" };
            var json = JsonConvert.SerializeObject(request);
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
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.DeserializeObject<Request>(rcv, settings);
        }
        public void Run()
        {
            NetworkStream stream = client.GetStream();
            SendRequest(stream);
            while (true)
            {
                Request request = ReceiveRequest(stream);
                if (request.Type.Equals("RESPONSEPLANES"))
                {
                    flightPlans = _formatterContext.FormatFlightPlanes(request.Planes);
                    planes = _formatterContext.FormatPlanes(request.Planes);
                    foreach (FlightPlanDTO flightPlan in flightPlans)
                    {
                        context.Add(flightPlan);
                    }
                    context.SaveChanges();

                    foreach (PlaneDTO plane in planes)
                    {
                        context.Add(plane);
                    }
                    context.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            
        }
    }
}
public class Request
{
    public string Type { get; set; }
    public List<Plane> Planes { get; set; }
}