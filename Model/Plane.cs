using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.Model
{
    public class Plane
    {
        public string CallSign { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public FlightPlan FlightPlan { get; set; }
        public Position Position { get; set; }
        public string Status { get; set; } = "In air";
        public override string ToString()
        {
            return $"CallSign: {CallSign} \nModel:{Model} \nCompany: {Company} \nFlightPlan: {FlightPlan} \nPosition: {Position} \nStatus: {Status}";
        }
    }
}
