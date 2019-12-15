namespace SEP3_TIER2_API.Model
{
    public class Plane
    {
        public string RegistrationNo { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public FlightPlan FlightPlan { get; set; }
        public Position PlanePosition { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return $"RegNo: {RegistrationNo} \nModel:{Model} \nCompany: {Company} \nFlightPlan: {FlightPlan} \nPosition: {PlanePosition} \nStatus: {Status}";
        }
    }
}
