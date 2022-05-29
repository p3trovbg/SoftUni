using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace _03._Speed_Racing
{
    class Car
    {
        //model, fuel amount, fuel consumption per kilometer
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double ConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public Car(string model, double fuel, double consumptionPerKilometer, double distance)
        {
            Model = model;
            Fuel = fuel;
            ConsumptionPerKilometer = consumptionPerKilometer;
            TraveledDistance = distance;
        }
        public bool CanMove(double fuel, double consumption, double distance)
        {
            if (fuel >= consumption * distance)
            {
                return true;
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                double fuel = double.Parse(data[1]);
                double consumption = double.Parse(data[2]);
                double distance = 0;
                Car car = new Car(model, fuel, consumption, distance);
                cars.Add(car);
            }

            //Chek for distance and expense
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split();
                string model = data[1];
                double distance = double.Parse(data[2]);

                List<Car> currentCar = cars.Where(x => x.Model == model).ToList();
                double fuel = currentCar[0].Fuel;
                double consumptionPerKilometer = currentCar[0].ConsumptionPerKilometer;

                if (currentCar[0].CanMove(fuel, consumptionPerKilometer, distance))
                {
                    currentCar[0].Fuel -=consumptionPerKilometer * distance;
                    currentCar[0].TraveledDistance += distance;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            //PRINT OUTPUT
            foreach (var currentCar in cars)
            {
                Console.WriteLine($"{currentCar.Model} {currentCar.Fuel:F2} {currentCar.TraveledDistance}");
            }
        }
    }
}
