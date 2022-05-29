using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicles
    {
        public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {

        }
        public bool IsEmpty { get; set; }
        public override double ConsumptionPerKm 
            => this.IsEmpty ? base.ConsumptionPerKm : base.ConsumptionPerKm + 1.4;
        public override void Drive(double distance) => base.Drive(distance);  
        public override void Refuel(double fuel) => base.Refuel(fuel);
    }
}
