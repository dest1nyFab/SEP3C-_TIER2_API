using SEP3_TIER2_API.Model;
using System.Collections.Generic;

namespace SEP3_TIER2_API.DTOFormat
{
    public class DTOFormatter:IDTOFormatter
    {
        public List<FlightPlanDTO> FormatFlightPlanes(List<Plane> planes)
        {
            List<FlightPlanDTO> planeList = new List<FlightPlanDTO>();
            foreach (Plane plane in planes)
            {
                planeList.Add(new FlightPlanDTO { CallSign = plane.FlightPlan.CallSign, Model = plane.Model, Company = plane.Company, FlightNumber = plane.FlightPlan.FlightNumber, StartLocation = plane.FlightPlan.StartLocation, EndLocation = plane.FlightPlan.EndLocation, DepartureTime = ConvertTime(plane.FlightPlan.DepartureTime), ArrivalTime = ConvertTime(plane.FlightPlan.ArrivalTime), Status = plane.Status});
            }
            return planeList;
        }
        public List<PlaneDTO> FormatPlanes(List<Plane> planes)
        {
            List<PlaneDTO> planeList = new List<PlaneDTO>();
            foreach (Plane plane in planes)
            {
                planeList.Add(new PlaneDTO { RegistrationNo =plane.RegistrationNo, Model = plane.Model, Company = plane.Company});
            }
            return planeList;
        }
        private static string ConvertTime(FlightDate date)
        {
            string s = "";
            if (date.Day < 10)
            {
                s += "0" + date.Day + "/";
            }
            else
            {
                s += date.Day + "/";
            }
            if (date.Month < 10)
            {
                s += "0" + date.Month + "/";
            }
            else
            {
                s += date.Month + "/";
            }

            s += date.Year + " ";

            if (date.Hour < 10)
            {
                s += "0" + date.Hour + ":";
            }
            else
            {
                s += date.Hour + ":";
            }

            if (date.Minutes < 10)
            {
                s += "0" + date.Minutes + ":";
            }
            else
            {
                s += date.Minutes + ":";
            }

            if (date.Seconds < 10)
            {
                s += "0" + date.Seconds;
            }
            else
            {
                s += date.Seconds;
            }
            return s;
        }
    }
}
