using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

       
        public string Make
        {
            get => make;
            set => make = value;
        }
        public string Model
        {
            get => model;
            set => model = value;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }
        public double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }
        public Engine Engine 
        {
            get => engine; set => engine = value;
        }
        public Tire[] Tires 
        { 
            get => tires; set => tires = value;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine,
            Tire[] tire)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            
            this.Engine = engine;
            this.Tires = tire;
        }
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
        : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        : this (make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public void Drive(double distance)
        {
            double fuelConsumed = distance * (fuelConsumption / 100);
            if (fuelQuantity - fuelConsumed >= 0)
            {
                fuelQuantity -= fuelConsumed;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            var sb = new StringBuilder();
           sb.AppendLine($"Make: {Make}");
           sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Year: {Year}");
            sb.AppendLine($"HorsePowers: {Engine.HorsePower}");
            sb.Append($"FuelQuantity: {FuelQuantity}");
            return sb.ToString();
        }
    }
}
