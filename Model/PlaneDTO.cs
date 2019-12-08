using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEP3_TIER2_Client.Model
{
    public class PlaneDTO
    {
        [Key]
        public string CallSign { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Delay { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}