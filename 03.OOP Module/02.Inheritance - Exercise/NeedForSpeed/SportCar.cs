using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public double DefaultFuelConsumption = 10;
        public SportCar(double fuel, int horsePower) 
            : base(fuel, horsePower)
        {
        }
        override public double FuelConsumtion => DefaultFuelConsumption;  
    }
}
