using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace ATCSimTest
{
    class Aircraft
    {
        public Callsign Callsign{ get; set; }
        public int Level { get; set; }
        public int Heading { get; set; }
        public int GroundSpeed { get; set; }
        public Coordinates Position { get; set; }

        public bool InTurn;
        public bool InLvlChange;

        public bool Identified;
        public bool Transfered;

        public int ClearedLevel { get; set; }
        public int ClearedHeading { get; set; }
        public int ClearedSpeed { get; set; }

        public Queue<Point> trail;

        public Aircraft(string cs, int lvl, int hdg, int gs, double posX, double posY)
        {
            Callsign = new Callsign(cs);
            Level = lvl;
            Heading = hdg;
            GroundSpeed = gs;
            Position = new Coordinates(posX, posY);
            trail = new Queue<Point>();

            ClearedHeading = Heading;
            ClearedLevel = Level;
        }

        public void MovementContinue(int t, int scale)
        {
            trail.Enqueue(new Point((int)Position.X, (int)Position.Y));
            double dy = -1 * (Math.Cos(Heading * Math.PI / 180.0) * ( scale * GroundSpeed / 3600 * t ));
            double dx = Math.Sin(Heading * Math.PI / 180.0) * (scale * GroundSpeed / 3600 * t);
            Position.Translate(dx, dy);
            //Limit trail length to 5
            if (trail.Count > 5)
            {
                trail.Dequeue();
            }
        }

        public void TurnContinue(int t, int angleStep = 3)
        {
            if (ClearedHeading != Heading)
            {
                if (ClearedHeading < Heading && ClearedHeading > Heading + angleStep)
                {
                    Heading = ClearedHeading;
                }
                else if (ClearedHeading > Heading && ClearedHeading < Heading + angleStep)
                {
                    Heading = angleStep;
                }
                else
                {
                    Heading += angleStep;
                    NormalizeHdg();
                }
            }
            if (ClearedHeading == Heading)
            {
                InTurn = false;
            }
        }

        public void NormalizeHdg()
        {
            Heading = Heading < 0 ? Heading + 360 : Heading;
            Heading = Heading > 360 ? Heading - 360 : Heading;
        }
        
    }

}
