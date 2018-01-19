using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCSimTest
{
    class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinates()
        {
            this.X = 0d;
            this.Y = 0d;
        }

        public Coordinates(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Translate(double dx, double dy)
        {
            this.X += dx;
            this.Y += dy;
        }

        public bool Equals(Coordinates other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public double Distance(Coordinates other)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(this.X - other.X), 2) + Math.Pow(Math.Abs(this.Y - other.Y), 2));
        }
    }

}
