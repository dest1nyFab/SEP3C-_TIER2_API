using SEP3_TIER2_API.Model;
using System.Collections.Generic;

namespace SEP3_TIER2_API.DTOFormat
{
    public interface IDTOFormatter
    {
        public List<FlightPlanDTO> FormatFlightPlanes(List<Plane> planes);
        public List<PlaneDTO> FormatPlanes(List<Plane> planes);
    }
}
