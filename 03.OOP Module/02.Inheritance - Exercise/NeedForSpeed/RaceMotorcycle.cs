using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public double DefaultFuelConsumption = 8;
        public RaceMotorcycle(double fuel, int horsePower) 
            : base(fuel, horsePower)
        {

        }

        public override double FuelConsumtion
            => DefaultFuelConsumption;
    }
}
