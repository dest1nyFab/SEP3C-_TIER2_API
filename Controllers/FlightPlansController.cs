using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3_TIER2_API.Model;
using SEP3_TIER2_API.Networking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightPlansController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IServerHandler _handlerContext;

        public FlightPlansController(APIContext context, IServerHandler handler)
        {
            _context = context;
            _handlerContext = handler;
        }

        // GET: /FlightPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightPlanDTO>>> GetPlanes()
        {
            if (!_context.FlightPlans.Any())
            {
                return NoContent();
            }
            return await _context.FlightPlans.ToListAsync();
        }

        // POST: /FlightPlans
        [HttpPost]
        public async Task<ActionResult<FlightPlanDTO>> PostPlane(FlightPlanDTO plane)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            if(plane.FlightNumber == 0)
            {
                plane.FlightNumber = getMaxIndex() + 1;
            }
            _context.FlightPlans.Add(plane);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: /FlightPlans/CallSign
        [HttpDelete]
        [Route("{CallSign}")]
        public async Task<ActionResult<FlightPlanDTO>> DeletePlane(string CallSign)
        {
            var plane = await _context.FlightPlans.FindAsync(CallSign);
            if (plane == null)
            {
                return NotFound();
            }
            _context.FlightPlans.Remove(plane);
            await _context.SaveChangesAsync();
            return plane;
        }

        private int getMaxIndex()
        {
            return _context.FlightPlans.Max(plane => plane.FlightNumber);
        }
    }
}