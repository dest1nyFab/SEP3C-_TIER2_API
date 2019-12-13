using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3_TIER2_API.Model;
using SEP3_TIER2_API.Networking;
using SEP3_TIER2_Client.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly APIContext _context;
        private IServerHandler _handlerContext;

        public PlanesController(APIContext context, IServerHandler handler)
        {
            _context = context;
            _handlerContext = handler;
        }

        // GET: /Planes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaneDTO>>> GetPlanes()
        {
            if (_context.Planes.Count() == 0)
            {
                return NoContent();
            }
            return await _context.Planes.ToListAsync();
        }

        // POST: /Planes
        [HttpPost]
        public async Task<ActionResult<PlaneDTO>> PostPlane(PlaneDTO plane)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            if(plane.FlightNumber == 0)
            {
                plane.FlightNumber = getMaxIndex() + 1;
            }
            _context.Planes.Add(plane);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: /Planes/CallSign
        [HttpDelete]
        [Route("{CallSign}")]
        public async Task<ActionResult<PlaneDTO>> DeletePlane(string CallSign)
        {
            var plane = await _context.Planes.FindAsync(CallSign);
            if (plane == null)
            {
                return NotFound();
            }
            _context.Planes.Remove(plane);
            await _context.SaveChangesAsync();
            return plane;
        }

        private int getMaxIndex()
        {
            return _context.Planes.Max(plane => plane.FlightNumber);
        }
    }
}