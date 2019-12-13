using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER2_API.Model
{
    public class FlightPlanDTO
    {
        [Key]
        [StringLength(10, MinimumLength = 3)]
        public string CallSign { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public int FlightNumber { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        [StringLength(19)]
        public string DepartureTime { get; set; }
        [StringLength(19)]
        public string ArrivalTime { get; set; }
        public string Status { get; set; }
    }
}