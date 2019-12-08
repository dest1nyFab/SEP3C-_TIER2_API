using SEP3_TIER2_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.APIHandler
{
    public class APIFeedHandler
    {
        public static HttpClient client;

        public APIFeedHandler()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44397/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Uri> PostPlaneAsync(PlaneDTO plane)
        {
            Console.WriteLine(JsonSerializer.Serialize(plane));
            HttpResponseMessage response = await client.PostAsJsonAsync("planes", plane);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public void Apply(PlaneDTO plane)
        {
            PostPlaneAsync(plane).GetAwaiter().GetResult();
        }

        public async Task FeedAPI(PlaneDTO plane)
        {
            try
            {
                var url = await PostPlaneAsync(plane);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
