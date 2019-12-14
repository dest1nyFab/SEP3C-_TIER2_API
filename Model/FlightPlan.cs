namespace SEP3_TIER2_API.Model
{
    public class FlightPlan
    {
        public string CallSign { get; set; }
        public int FlightNumber { get; set; }
        public FlightDate DepartureTime { get; set; }
        public FlightDate ArrivalTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public override string ToString()
        {
            return $"CallSign: {CallSign}\nId: {FlightNumber} \nDepartureTime: {DepartureTime} \nArrivalTime: {ArrivalTime} \nStartLocation: {StartLocation} \nEndLocation: {EndLocation}";
        }
    }
}
