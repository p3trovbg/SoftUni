using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public double DefaultFuelConsumption = 3;
        public Car(double fuel, int horsePower) 
            
            : base(fuel, horsePower)
        {
        }

        public override double FuelConsumtion => DefaultFuelConsumption;
    }
}
