using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCSimTest
{
    class Callsign
    {
        public string Code { get; set; }
        public string airlineOp;
        public string flightNum;
        //public string registration;
        //public string speechCallsign;


        public Callsign(string s)
        {
            this.Code = s;
            this.ParseCallsign();
        }
        
        public void ParseCallsign()
        {
            airlineOp = Code.Substring(0, 3);
            flightNum = Code.Substring(3);

            // To be implemented:
            // Speech recognition handles
        }
        public override string ToString()
        {
            return this.Code;
        }

        public bool Equals(string s)
        {
            return this.Code == s;
        }
    }
}
