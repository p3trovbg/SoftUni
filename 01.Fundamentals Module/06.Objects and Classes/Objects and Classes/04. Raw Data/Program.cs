using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Raw_Data
{
    class Car
    {

        public Car(string model, int engineSpeed, int enginePower, int cargoWeith, string cargoType)
        {
            Model = model;
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
            CargoWeight = cargoWeith;
            CargoType = cargoType;
        }
        public string Model { get; set; }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> list = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower =int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string type = data[4];
                Car currentCar = new Car(model, engineSpeed, enginePower, cargoWeight, type);
                list.Add(currentCar);
            }

            string types = Console.ReadLine();
            List<Car> result = list.Where(x => x.CargoType == types).ToList();
            foreach (var cars in result)
            {
                if (cars.CargoType == "fragile")
                {
                    if (cars.CargoWeight < 1000)
                    {
                        Console.WriteLine(cars.Model);
                    }
                }
                else if (cars.CargoType == "flamable")
                {
                    if (cars.EnginePower > 250)
                    {
                        Console.WriteLine(cars.Model);
                    }
                }
            }

        }
    }
}
