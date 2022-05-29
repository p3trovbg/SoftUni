using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(double fuel, int horsePower)
        {
            Fuel = fuel;
            HorsePower = horsePower;
            FuelConsumtion = DefaultFuelConsumption;
        }

        public double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumtion { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumtion;

        }
    }
}