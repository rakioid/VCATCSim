using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCSimTest
{
    class FlightPlan
    {
        public Callsign Callsign { get; set; }
        public char FlightRules { get; set; }
        public char TypeOfFlight { get; set; }
        public string AcType { get; set; }
        public char WTC { get; set; }
        public string EquipmentAndCapabilities { get; set; }
        public string ADEP { get; set; }
        public string EOBT { get; set; }
        public int CruisingSpeed { get; set; }
        public int CruiseLevel { get; set; }
        public Route Route { get; set; }
        public string ADES { get; set; }
        public string EET { get; set; }
        public string ALTN { get; set; }
        public string ALTN2 { get; set; }
        public string OtherInfo { get; set; }

        public FlightPlan()
        {

        }
    }

    class Route
    {
        public string FullRoute { get; set; }

    }
}
