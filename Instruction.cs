using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ATCSimTest
{
    class Instruction
    {
        public string Callsign { get; set; }
        public string Clearance { get; set; }
        public string Information { get; set; }
        public string Negative { get; set; }

        PromptBuilder readback;

        public Instruction(string cs, string clc, string info, string neg)
        {
            Callsign = cs;
            if (clc != "N")
            {
                clc = clc.Substring(1);
            }
            Clearance = clc;
            Information = info;
            Negative = neg;
            readback = new PromptBuilder();
        }
        
        public string[] ParseClc()
        {
            if (Clearance == "N")
            {
                return null;
            }
            string[] clearances = Clearance.Split('|');
            return clearances;
        }
    }
}
