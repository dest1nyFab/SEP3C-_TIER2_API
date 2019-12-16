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
        public async Task<ActionResult<IEnumerable<FlightPlanDTO>>> GetFlightPlans()
        {
            if (!_context.FlightPlans.Any())
            {
                return NoContent();
            }
            return await _context.FlightPlans.ToListAsync();
        }

        // POST: /FlightPlans
        [HttpPost]
        public async Task<ActionResult<FlightPlanDTO>> PostFlightPlan(FlightPlanDTO flightPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            if (flightPlan.FlightNumber == 0)
            {
                flightPlan.FlightNumber = getFlightPlanIndex();
            }
            var plane = _context.Planes.Single(p => p.RegistrationNo.Equals(flightPlan.Model));
            flightPlan.Model = plane.Model;
            _context.FlightPlans.Add(flightPlan);
            await _context.SaveChangesAsync();
            var startDate = new FlightDate(int.Parse(flightPlan.ArrivalTime.Substring(0, 2)), int.Parse(flightPlan.ArrivalTime.Substring(3, 2)), int.Parse(flightPlan.ArrivalTime.Substring(6, 4)), int.Parse(flightPlan.ArrivalTime.Substring(11, 2)), int.Parse(flightPlan.ArrivalTime.Substring(14, 2)), int.Parse(flightPlan.ArrivalTime.Substring(17, 2)));
            var endDate = new FlightDate(int.Parse(flightPlan.DepartureTime.Substring(0, 2)), int.Parse(flightPlan.DepartureTime.Substring(3, 2)), int.Parse(flightPlan.DepartureTime.Substring(6, 4)), int.Parse(flightPlan.DepartureTime.Substring(11, 2)), int.Parse(flightPlan.DepartureTime.Substring(14, 2)), int.Parse(flightPlan.DepartureTime.Substring(17, 2)));
            var flightPlanToSend = new FlightPlan { CallSign = flightPlan.CallSign, FlightNumber = flightPlan.FlightNumber, StartLocation = flightPlan.StartLocation, EndLocation = flightPlan.EndLocation, ArrivalTime = startDate, DepartureTime = endDate};
            var planeWithPlan = new Plane { Company = plane.Company, FlightPlan = flightPlanToSend, Model = plane.Model, Status = plane.Status, RegistrationNo = plane.RegistrationNo};
            _handlerContext.AddFlightPlan(planeWithPlan);
            return Ok();
        }

        // DELETE: /FlightPlans/CallSign
        [HttpDelete]
        [Route("{CallSign}")]
        public async Task<ActionResult<FlightPlanDTO>> DeleteFlightPlan(string CallSign)
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
