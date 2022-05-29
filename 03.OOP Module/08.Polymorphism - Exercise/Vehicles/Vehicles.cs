using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicles
    {

        protected Vehicles(double fuelQuantity, double consumptionPerKm, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            ConsumptionPerKm = consumptionPerKm;
            TankCapacity = tankCapacity;
        }
        public double TankCapacity { get; protected set; }
        public double FuelQuantity { get; protected set; }
        public virtual double ConsumptionPerKm { get; protected set; }
        public virtual void Drive(double distance)
        {
            if (FuelQuantity - distance * ConsumptionPerKm >= 0)
            {
                FuelQuantity -= distance * ConsumptionPerKm;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            if (GetType().Name == "Truck")
            {
                fuel *= 0.95;
            }
            FuelQuantity += fuel;
        }
    }
}
