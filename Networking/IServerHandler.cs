using SEP3_TIER2_API.Model;

namespace SEP3_TIER2_API.Networking
{
    public interface IServerHandler
    {
        void DeleteFlightPlan(string callSign);
        void AddFlightPlan(Plane planeWithPlan);
    }
}
