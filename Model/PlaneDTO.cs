using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER2_Client.Model
{
    public class PlaneDTO
    {
        [Key]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string CallSign { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Model { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Company { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string StartLocation { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string EndLocation { get; set; }

        [StringLength(12)]
        public string DepartureTime { get; set; }

        [StringLength(12)]
        public string ArrivalTime { get; set; }
    }
}