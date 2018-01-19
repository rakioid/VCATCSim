using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCSimTest
{
    class Exercise
    {
        public int AircraftNum { get; set; }
        public List<Aircraft> acList;

        public Exercise(int acn)
        {
            acList = new List<Aircraft>();
            AircraftNum = acn;

            switch (AircraftNum)
            {
                case 1:
                    acList.Add(new Aircraft("BAW105", 310, 120, 360, 20, 40));
                    break;
                case 2:
                    acList.Add(new Aircraft("BAW105", 310, 120, 360, 20, 40));
                    acList.Add(new Aircraft("DLH2E", 340, 240, 380, 320, 35));
                    break;
                case 3:
                    acList.Add(new Aircraft("BAW105", 310, 120, 360, 20, 60));
                    acList.Add(new Aircraft("DLH2E", 340, 240, 420, 320, 35));
                    acList.Add(new Aircraft("THY719", 320, 310, 380, 500, 270));
                    break;
                default:
                    break;
            }
        }
    }
}
