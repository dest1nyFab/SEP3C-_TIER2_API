using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEP3_TIER2_Client.Model
{
    public class Plane
    {
        [Key]
        public string Flight { get; set; }
        public string Airplane { get; set; }
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Delay { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public override string ToString()
        {
            return $"Flight: {Flight}\nAirline: {Airline}\nOrigin: {Origin}\nDestination: {Destination}\nDelay: {Delay}\nArrivartime: {ArrivalTime}\nDepartureTime: {DepartureTime}";
        }
    }
}