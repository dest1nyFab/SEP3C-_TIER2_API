using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.Model
{
    public class FlightPlan
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime Delay { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} \nDepartureTime: {DepartureTime} \nArrivalTime: {ArrivalTime} \nDelay: {Delay}\nStartLocation: {StartLocation} \nEndLocation: {EndLocation}";
        }
    }
}
