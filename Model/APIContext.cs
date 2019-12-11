using Microsoft.EntityFrameworkCore;
using SEP3_TIER2_Client.Model;

namespace SEP3_TIER2_API.Model
{
    public class APIContext: DbContext
    {

        public APIContext(DbContextOptions<APIContext> options): base(options)
        {

        }

        public DbSet<PlaneDTO> Planes { get; set; }
    }
}
