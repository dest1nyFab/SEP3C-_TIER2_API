using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3_TIER2_API.Context;
using SEP3_TIER2_API.DTO;
using SEP3_TIER2_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly APIContext _context;

        public PlanesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Planes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaneDTO>>> GetPlanes()
        {
            return await _context.Planes.ToListAsync();
        }
    }
}
