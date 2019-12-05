using Microsoft.EntityFrameworkCore;
using SEP3_TIER2_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.Model
{
    public class APIContext: DbContext
    {

        public APIContext(DbContextOptions<APIContext> options): base(options)
        {

        }

        public DbSet<Plane> Planes { get; set; }
    }
}
