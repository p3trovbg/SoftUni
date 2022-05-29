using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }

        public override double ConsumptionPerKm => base.ConsumptionPerKm + 1.6;
        public override void Drive(double distance) => base.Drive(distance);

        public override void Refuel(double fuel) => base.Refuel(fuel);
    }
}
