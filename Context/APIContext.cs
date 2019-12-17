using Microsoft.EntityFrameworkCore;
using SEP3_TIER2_API.DTO;
using SEP3_TIER2_API.Model;

namespace SEP3_TIER2_API.Context
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public DbSet<FlightPlanDTO> FlightPlans { get; set; }
        public DbSet<PlaneDTO> Planes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightPlanDTO>().HasKey(fp => new {fp.CallSign, fp.FlightNumber });      
        }
    }
}
