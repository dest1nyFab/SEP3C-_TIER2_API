using SEP3_TIER2_API.Model;
using SEP3_TIER2_Client.Model;
using System.Collections.Generic;
using System.Diagnostics;

namespace SEP3_TIER2_API.DTOFormatter
{
    public class DTOFormatter
    {
        public static List<PlaneDTO> FormatPlanes(List<Plane> planes)
        {
            List<PlaneDTO> planeList = new List<PlaneDTO>();
            foreach (Plane plane in planes)
            {            
                planeList.Add(new PlaneDTO { CallSign = plane.CallSign, Model = plane.Model, Company = plane.Company, StartLocation = plane.FlightPlan.StartLocation, EndLocation = plane.FlightPlan.EndLocation, DepartureTime = ConvertTime(plane.FlightPlan.DepartureTime), ArrivalTime = ConvertTime(plane.FlightPlan.ArrivalTime), FlightNumber = plane.FlightPlan.FlightNumber});
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
