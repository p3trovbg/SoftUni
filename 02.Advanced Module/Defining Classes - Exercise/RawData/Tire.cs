using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        public int TireAge { get; set; }
        public double Pressure { get; set; }

        public Tire(int tireAge, double pressure)
        {
            TireAge = tireAge;
            Pressure = pressure;
        }
    }
}
