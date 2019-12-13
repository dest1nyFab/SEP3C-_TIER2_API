﻿using Microsoft.EntityFrameworkCore;

namespace SEP3_TIER2_API.Model
{
    public class APIContext: DbContext
    {

        public APIContext(DbContextOptions<APIContext> options): base(options)
        {

        }

        public DbSet<FlightPlanDTO> FlightPlans { get; set; }
        public DbSet<PlaneDTO> Planes { get; set; }
    }
}
