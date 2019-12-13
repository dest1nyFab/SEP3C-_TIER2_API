using SEP3_TIER2_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.DTOFormat
{
    public interface IDTOFormatter
    {
        public List<FlightPlanDTO> FormatFlightPlanes(List<Plane> planes);
        public List<PlaneDTO> FormatPlanes(List<Plane> planes);
    }
}
