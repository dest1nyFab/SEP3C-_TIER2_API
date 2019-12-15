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
            if (plane.FlightNumber == 0)
            {
                plane.FlightNumber = getFlightPlanIndex();
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
            var flightPlan = await _context.FlightPlans.FindAsync(CallSign);
            if (flightPlan == null)
            {
                return NotFound();
            }
            _context.FlightPlans.Remove(flightPlan);
            await _context.SaveChangesAsync();
            _handlerContext.DeleteFlightPlan(flightPlan.CallSign);
            return flightPlan;
        }

        private int getFlightPlanIndex()
        {
            int i = 0;
            foreach (FlightPlanDTO flightPlan in _context.FlightPlans.OrderBy(flightPlan => flightPlan.FlightNumber))
            {
                if (i == flightPlan.FlightNumber)
                {
                    i++;
                }
                else
                {
                    return i;
                }
            }
            return _context.FlightPlans.Max(plane => plane.FlightNumber) + 1;
        }
    }
}
