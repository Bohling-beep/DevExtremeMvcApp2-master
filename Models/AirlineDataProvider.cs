using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DevExtremeMvcApp2.Models
{
    public static class AirlineDataProvider
    {
        const string
            FlightsSessionKey = "DX_Flights",
            DependenciesSessionKey = "DX_FlightDependencies",
            PlanesSessionKey = "DX_Planes",
            AssignmentsSessionKey = "DX_Flight_Planes_Assignmnents";

        static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static object GetFlights() { return Flights; }
        public static object GetDependencies() { return Dependencies; }
        public static object GetPlanes() { return Planes; }
        public static object GetAssignments() { return Assignments; }

        public static List<Flight> Flights
        {
            get
            {
                if (Session[FlightsSessionKey] == null)
                    Session[FlightsSessionKey] = CreateFlights();
                else
                    UpdateFlightsProgress();
                return (List<Flight>)Session[FlightsSessionKey];
            }
        }
        public static List<FlightDependency> Dependencies
        {
            get
            {
                if (Session[DependenciesSessionKey] == null)
                    Session[DependenciesSessionKey] = CreateDependencies();
                return (List<FlightDependency>)Session[DependenciesSessionKey];
            }
        }
        public static List<Plane> Planes
        {
            get
            {
                if (Session[PlanesSessionKey] == null)
                    Session[PlanesSessionKey] = CreatePlanes();
                return (List<Plane>)Session[PlanesSessionKey];
            }
        }
        public static List<Assignment> Assignments
        {
            get
            {
                if (Session[AssignmentsSessionKey] == null)
                    Session[AssignmentsSessionKey] = CreateAssignments();
                return (List<Assignment>)Session[AssignmentsSessionKey];
            }
        }

        static List<Flight> CreateFlights()
        {
            var result = new List<Flight>();


            // MIA > LAX
            var start = DateTime.Now.Date.AddHours(0.5);
            result.Add(new Flight("US251", "", "Miami (MIA)", null, "Los-Angeles (LAX)", null, 2540));
            result.Add(new Flight("US253", "US251", "Miami (MIA)", start, "Atlanta (ATL)", start.AddHours(1.5), 600));
            result.Add(new Flight("US255", "US251", "Atlanta (ATL)", start.AddHours(2), "Dallas (DAL)", start.AddHours(4), 724));
            result.Add(new Flight("US257", "US251", "Dallas (DAL)", start.AddHours(5.5), "Los-Angeles (LAX)", start.AddHours(8.5), 1216));

            result.Add(new Flight("US101", "", "New York (JFK)", start.AddHours(0.5), "Sydney (SYD)", start.AddHours(19.5), 10072, true));

            //JFK > LAX
            start = DateTime.Now.Date.AddHours(6);
            result.Add(new Flight("US201", "", "New York (JFK)", null, "Los-Angeles (LAX)", null, 2557));
            result.Add(new Flight("US205", "US201", "New York (JFK)", start, "Chicago (ORD)", start.AddHours(2), 718));
            result.Add(new Flight("US209", "US201", "Chicago (ORD)", start.AddHours(3), "Salt Lake City (SLC)", start.AddHours(6), 1261));
            result.Add(new Flight("US211", "US201", "Salt Lake City (SLC)", start.AddHours(6.5), "Los-Angeles (LAX)", start.AddHours(8), 578));

            // IAH > SLC
            start = DateTime.Now.Date.AddHours(4);
            result.Add(new Flight("US217", "", "Houston (IAH)", null, "Salt Lake City (SLC)", null, 1287));
            result.Add(new Flight("US221", "US217", "Houston (IAH)", start, "Oklahoma City (OKC)", start.AddHours(1), 417));
            result.Add(new Flight("US225", "US217", "Oklahoma City (OKC)", start.AddHours(2), "Salt Lake City (SLC)", start.AddHours(3.7), 870));

            // MIA > YYZ
            start = DateTime.Now.Date.AddHours(9);
            result.Add(new Flight("US231", "", "Miami (MIA)", null, "Toronto (YYZ)", null, 1582));
            result.Add(new Flight("US235", "US231", "Miami (MIA)", start, "Charleston (CHS)", start.AddHours(1), 482));
            result.Add(new Flight("US237", "US231", "Charleston (CHS)", start.AddHours(2), "Philadelphia (PHL)", start.AddHours(3), 560));
            result.Add(new Flight("US243", "US231", "Philadelphia (PHL)", start.AddHours(4), "Toronto (YYZ)", start.AddHours(5.8), 540, true));

            // LAX > JFK
            start = DateTime.Now.Date.AddHours(14);
            result.Add(new Flight("US202", "", "Los-Angeles (LAX)", null, "New York (JFK)", null, 2557));
            result.Add(new Flight("US206", "US202", "Los-Angeles (LAX)", start, "Salt Lake City (SLC)", start.AddHours(2), 578));
            result.Add(new Flight("US210", "US202", "Salt Lake City (SLC)", start.AddHours(3), "Chicago (ORD)", start.AddHours(6), 1261));
            result.Add(new Flight("US212", "US202", "Chicago (ORD)", start.AddHours(8), "New York (JFK)", start.AddHours(10.5), 718));

            start = DateTime.Now.Date.AddHours(11);
            result.Add(new Flight("US102", "", "Sydney (SYD)", start, "New York (JFK)", start.AddHours(20), 10072, true));

            // SLC > IAH
            start = DateTime.Now.Date.AddHours(16);
            result.Add(new Flight("US218", "", "Salt Lake City (SLC)", null, "Houston (IAH)", null, 1287));
            result.Add(new Flight("US222", "US218", "Salt Lake City (SLC)", start, "Oklahoma City (OKC)", start.AddHours(2), 870));
            result.Add(new Flight("US226", "US218", "Oklahoma City (OKC)", start.AddHours(3), "Oklahoma City (OKC)Houston (IAH)", start.AddHours(4), 417));

            // YYZ > MIA
            start = DateTime.Now.Date.AddHours(15);
            result.Add(new Flight("US232", "", "Toronto (YYZ)", null, "Miami (MIA)", null, 1582));
            result.Add(new Flight("US244", "US232", "Toronto (YYZ)", start, "Philadelphia (PHL)", start.AddHours(2), 540, true));
            result.Add(new Flight("US238", "US232", "Philadelphia (PHL)", start.AddHours(3), "Charleston (CHS)", start.AddHours(4.5), 560));
            result.Add(new Flight("US236", "US232", "Charleston (CHS)", start.AddHours(5.5), "Miami (MIA)", start.AddHours(6.5), 482));

            // LAX > MIA
            start = DateTime.Now.Date.AddHours(18);
            result.Add(new Flight("US252", "", "Los-Angeles (LAX)", null, "Miami (MIA)", null, 2540));
            result.Add(new Flight("US258", "US252", "Los-Angeles (LAX)", start, "Dallas (DAL)", start.AddHours(3), 1216));
            result.Add(new Flight("US256", "US252", "Dallas (DAL)", start.AddHours(4), "Atlanta (ATL)", start.AddHours(6), 724));
            result.Add(new Flight("US254", "US252", "Atlanta (ATL)", start.AddHours(7), "Miami (MIA)", start.AddHours(10.5), 600));

            return result;
        }

        static void UpdateFlightsProgress()
        {
            var flights = Session[FlightsSessionKey] as List<Flight>;
            if (flights != null)
            {
                foreach (Flight flight in flights)
                    flight.UpdateProgress();
            }
        }


        static List<FlightDependency> CreateDependencies()
        {
            var result = new List<FlightDependency>();

            result.Add(new FlightDependency() { PrevFlightId = "US205", NexFlightId = "US209", Type = 0 });
            result.Add(new FlightDependency() { PrevFlightId = "US209", NexFlightId = "US211", Type = 0 });

            result.Add(new FlightDependency() { PrevFlightId = "US221", NexFlightId = "US225", Type = 0 });

            result.Add(new FlightDependency() { PrevFlightId = "US235", NexFlightId = "US237", Type = 0 });
            result.Add(new FlightDependency() { PrevFlightId = "US237", NexFlightId = "US243", Type = 0 });

            result.Add(new FlightDependency() { PrevFlightId = "US253", NexFlightId = "US255", Type = 0 });
            result.Add(new FlightDependency() { PrevFlightId = "US255", NexFlightId = "US257", Type = 0 });

            result.Add(new FlightDependency() { PrevFlightId = "US206", NexFlightId = "US210", Type = 0 });
            result.Add(new FlightDependency() { PrevFlightId = "US210", NexFlightId = "US212", Type = 0 });

            result.Add(new FlightDependency() { PrevFlightId = "US222", NexFlightId = "US226", Type = 0 });

            result.Add(new FlightDependency() { PrevFlightId = "US244", NexFlightId = "US238", Type = 0 });
            result.Add(new FlightDependency() { PrevFlightId = "US238", NexFlightId = "US236", Type = 0 });

            result.Add(new FlightDependency() { PrevFlightId = "US258", NexFlightId = "US256", Type = 0 });
            result.Add(new FlightDependency() { PrevFlightId = "US256", NexFlightId = "US254", Type = 0 });

            return result;
        }

        static List<Plane> CreatePlanes()
        {
            var result = new List<Plane>();
            result.Add(new Plane() { SideNumber = "VQ-BPR", Model = "Boeing 737" });
            result.Add(new Plane() { SideNumber = "VQ-BOK", Model = "Boeing 737" });
            result.Add(new Plane() { SideNumber = "VQ-BHL", Model = "Boeing 737" });

            result.Add(new Plane() { SideNumber = "VQ-BHP", Model = "Boeing 767" });
            result.Add(new Plane() { SideNumber = "VQ-BPL", Model = "Boeing 767" });

            result.Add(new Plane() { SideNumber = "VQ-BBM", Model = "Boeing 777" });
            result.Add(new Plane() { SideNumber = "VQ-BER", Model = "Boeing 777" });
            result.Add(new Plane() { SideNumber = "VQ-BSQ", Model = "Boeing 777" });

            result.Add(new Plane() { SideNumber = "VP-BMP", Model = "Airbus A319" });
            result.Add(new Plane() { SideNumber = "VP-BPQ", Model = "Airbus A319" });

            result.Add(new Plane() { SideNumber = "VP-BKW", Model = "Airbus A320" });
            result.Add(new Plane() { SideNumber = "VP-BLR", Model = "Airbus A320" });

            result.Add(new Plane() { SideNumber = "VP-BRN", Model = "Airbus A350" });
            result.Add(new Plane() { SideNumber = "VP-BAM", Model = "Airbus A350" });

            result.Add(new Plane() { SideNumber = "VP-BSK", Model = "Airbus A380" });

            return result;
        }
        static List<Assignment> CreateAssignments()
        {
            var result = new List<Assignment>();
            result.Add(new Assignment() { FigntID = "US101", PlaneID = "VP-BSK" });
            result.Add(new Assignment() { FigntID = "US102", PlaneID = "VP-BSK" });

            result.Add(new Assignment() { FigntID = "US201", PlaneID = "VQ-BBM" });
            result.Add(new Assignment() { FigntID = "US202", PlaneID = "VQ-BBM" });
            result.Add(new Assignment() { FigntID = "US205", PlaneID = "VQ-BBM" });
            result.Add(new Assignment() { FigntID = "US206", PlaneID = "VQ-BBM" });
            result.Add(new Assignment() { FigntID = "US209", PlaneID = "VQ-BBM" });
            result.Add(new Assignment() { FigntID = "US210", PlaneID = "VQ-BBM" });
            result.Add(new Assignment() { FigntID = "US211", PlaneID = "VQ-BBM" });
            result.Add(new Assignment() { FigntID = "US212", PlaneID = "VQ-BBM" });

            result.Add(new Assignment() { FigntID = "US217", PlaneID = "VP-BMP" });
            result.Add(new Assignment() { FigntID = "US218", PlaneID = "VP-BMP" });
            result.Add(new Assignment() { FigntID = "US221", PlaneID = "VP-BMP" });
            result.Add(new Assignment() { FigntID = "US222", PlaneID = "VP-BMP" });
            result.Add(new Assignment() { FigntID = "US225", PlaneID = "VP-BMP" });
            result.Add(new Assignment() { FigntID = "US226", PlaneID = "VP-BMP" });

            result.Add(new Assignment() { FigntID = "US231", PlaneID = "VQ-BPR" });
            result.Add(new Assignment() { FigntID = "US232", PlaneID = "VQ-BPR" });
            result.Add(new Assignment() { FigntID = "US235", PlaneID = "VQ-BPR" });
            result.Add(new Assignment() { FigntID = "US236", PlaneID = "VQ-BPR" });
            result.Add(new Assignment() { FigntID = "US237", PlaneID = "VQ-BPR" });
            result.Add(new Assignment() { FigntID = "US238", PlaneID = "VQ-BPR" });
            result.Add(new Assignment() { FigntID = "US243", PlaneID = "VQ-BPR" });
            result.Add(new Assignment() { FigntID = "US244", PlaneID = "VQ-BPR" });

            result.Add(new Assignment() { FigntID = "US251", PlaneID = "VQ-BSQ" });
            result.Add(new Assignment() { FigntID = "US252", PlaneID = "VQ-BSQ" });
            result.Add(new Assignment() { FigntID = "US253", PlaneID = "VQ-BSQ" });
            result.Add(new Assignment() { FigntID = "US254", PlaneID = "VQ-BSQ" });
            result.Add(new Assignment() { FigntID = "US255", PlaneID = "VQ-BSQ" });
            result.Add(new Assignment() { FigntID = "US256", PlaneID = "VQ-BSQ" });
            result.Add(new Assignment() { FigntID = "US257", PlaneID = "VQ-BSQ" });
            result.Add(new Assignment() { FigntID = "US258", PlaneID = "VQ-BSQ" });

            return result;
        }

    }

    public class Flight
    {
        public string FligntNumber { get; set; }
        public string CompositeFLightNumber { get; set; }
        public string DepartFrom { get; set; }
        public string ArriveTo { get; set; }
        public DateTime? FlightStart { get; set; }
        public DateTime? FlightEnd { get; set; }
        public bool International { get; set; }
        public double Miles { get; set; }

        public int Progress { get; set; }
        public Color? State { get; set; }
        public string Title
        {
            get { return String.Concat(DepartFrom, "- ", ArriveTo); }
            set { }
        }

        public Flight() { }
        public Flight(string id, string compositeFLight, string departCity, DateTime? start, string arriveCity, DateTime? end, double spread, bool intlFLight = false)
        {
            FligntNumber = id;
            if (!string.IsNullOrEmpty(compositeFLight))
                CompositeFLightNumber = compositeFLight;
            FlightStart = start;
            FlightEnd = end;

            DepartFrom = departCity;
            ArriveTo = arriveCity;

            Miles = spread;
            International = intlFLight;

            Progress = GetCurrentProgress();
            State = GetCurrentState();
        }

        int GetCurrentProgress()
        {
            if (!FlightStart.HasValue || !FlightEnd.HasValue) return 0;

            var progress = (int)Math.Ceiling((DateTime.Now - FlightStart.Value).TotalMilliseconds / (FlightEnd.Value - FlightStart.Value).TotalMilliseconds * 100);
            progress = Math.Min(progress, 100);
            progress = Math.Max(progress, 0);
            return progress;
        }

        Color? GetCurrentState()
        {
            if (!FlightStart.HasValue || !FlightEnd.HasValue) return null;

            if (Progress == 100)
                return ColorTranslator.FromHtml("#4caf50");
            if (Progress == 0)
                return ColorTranslator.FromHtml("#e53935");
            return ColorTranslator.FromHtml("#f9a825");
        }
        public void UpdateProgress()
        {
            Progress = GetCurrentProgress();
            State = GetCurrentState();
        }
    }

    public class Plane
    {
        public string Model { get; set; }
        public string SideNumber { get; set; }
        public string Title { get { return String.Format(Model + " ({0})", SideNumber); } }
    }
    public class Assignment
    {
        public Assignment()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; set; }
        public string FigntID { get; set; }
        public string PlaneID { get; set; }

    }
    public class FlightDependency
    {
        public FlightDependency()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; set; }
        public string PrevFlightId { get; set; }
        public string NexFlightId { get; set; }
        public int Type { get; set; }
    } 
}