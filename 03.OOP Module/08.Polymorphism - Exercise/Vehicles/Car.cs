using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    
    public class Car : Vehicles
    {
        public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }
        public override double ConsumptionPerKm => base.ConsumptionPerKm + 0.9;


        public override void Drive(double distance) => base.Drive(distance);
        public override void Refuel(double fuel) => base.Refuel(fuel);
    }
}