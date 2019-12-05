using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using SEP3_TIER2_API.Model;
using SEP3_TIER2_Client.Model;
using Microsoft.AspNetCore;

namespace SEP3_TIER2_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<APIContext>();
                    context.Database.EnsureCreated();
                    if (!context.Planes.Any())
                    {
                        Plane plane = new Plane
                        {
                            Airline = "Fab",
                            Airplane = "tabuz",
                            ArrivalTime = "poimarti",
                            DepartureTime = "nu striu sefu",
                            Delay = "oleaca",
                            Flight = "de-atata",
                            Destination = "gura ta",
                            Origin = "pula mea"
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
            }
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
