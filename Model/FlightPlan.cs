namespace SEP3_TIER2_API.Model
{
    public class FlightPlan
    {
        public int Id { get; }
        public FlightDate DepartureTime { get; set; }
        public FlightDate ArrivalTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} \nDepartureTime: {DepartureTime} \nArrivalTime: {ArrivalTime} \nStartLocation: {StartLocation} \nEndLocation: {EndLocation}";
        }
    }
}
