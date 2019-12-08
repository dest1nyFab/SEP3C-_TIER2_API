using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEP3_TIER2_API.Model;
using SEP3_TIER2_API.Networking;
using SEP3_TIER2_Client.Model;
using System;
using System.Linq;

namespace SEP3_TIER2_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            Client client = new Client { Ip = "10.152.194.2", Port = 6789 };

            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<APIContext>();
                client.SetupClient(context);
                context.Database.EnsureCreated();
                if (!context.Planes.Any())
                {
                    PlaneDTO plane = new PlaneDTO
                    {
                        CallSign = "Fab",
                        Model = "tabuz",
                        ArrivalTime = "poimarti",
                        DepartureTime = "nu striu sefu",
                        Delay = "oleaca",
                        Company = "de-atata",
                        EndLocation = "gura ta",
                        StartLocation = "pula mea"
                    };
                    context.Add(plane);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error has occured!");
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
