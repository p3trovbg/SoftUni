using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06._Vehicle_Catalogue
{
    class VehicleCatalog
    {
        public VehicleCatalog(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                $"Model: {this.Model}{Environment.NewLine}" +
                                $"Color: {this.Color}{Environment.NewLine}" +
                                $"Horsepower: {this.HorsePower}";

            return vehicleStr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<VehicleCatalog> catalogs = new List<VehicleCatalog>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] catalog = input.Split();
                string type = catalog[0];
                string model = catalog[1];
                string color = catalog[2];
                int power = int.Parse(catalog[3]);
                VehicleCatalog currentCatalog = new VehicleCatalog(type, model, color, power);
                catalogs.Add(currentCatalog);
            }

            double averageTruck = 0;
            double averageCar = 0;
            while (true)
            {
                string model = Console.ReadLine();
                if (model == "Close the Catalogue")
                {
                    break;
                }

                Console.WriteLine(catalogs.Find(x => x.Model == model));

            }

            var onlyCars = catalogs.Where(x => x.Type == "car").ToList();
            var onlyTrucks = catalogs.Where(x => x.Type == "truck").ToList();
            foreach (var car in onlyCars)
            {
                averageCar += car.HorsePower;
            }

            foreach (var truck in onlyTrucks)
            {
                averageTruck += truck.HorsePower;
            }

            double averageCarsHorsepower = averageCar / onlyCars.Count;
            double averageTrucksHorsepower = averageTruck / onlyTrucks.Count;

            if (onlyCars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (onlyTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}

