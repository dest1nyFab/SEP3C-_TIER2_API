using SEP3_TIER2_API.Model;
using SEP3_TIER2_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_TIER2_API.DTOFormatter
{
    public class DTOFormatter
    {
        public static List<PlaneDTO> FormatPlanes(List<Plane> planes)
        {
            List<PlaneDTO> planeList = new List<PlaneDTO>();
            foreach (Plane plane in planes)
            {
                planeList.Add(new PlaneDTO { CallSign = plane.CallSign, Model = plane.Model, Company = plane.Company, StartLocation = plane.FlightPlan.StartLocation, EndLocation = plane.FlightPlan.EndLocation, Delay = plane.FlightPlan.Delay.Hour.ToString() + ":" + plane.FlightPlan.Delay.Minute.ToString(), DepartureTime = plane.FlightPlan.DepartureTime.ToString("dd/MM/yyyy HH:mm"), ArrivalTime = plane.FlightPlan.ArrivalTime.ToString("dd/MM/yyyy HH:mm") });
            }
            return planeList;
        }
    }
}
