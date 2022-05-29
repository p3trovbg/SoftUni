using System;
using System.Collections.Generic;

namespace _03.Speed_Racing___second
{
    class Car
    {
        //model, fuel amount, fuel consumption per kilometer
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double ConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public Car(string model, double fuel, double consumptionPerKilometer, double distance = 0)
        {
            Model = model;
            Fuel = fuel;
            ConsumptionPerKilometer = consumptionPerKilometer;
            TraveledDistance = distance;
        }
        public bool IsMove(string model, double distance)
        {
            if (Model == model)
            {
                if (Fuel >= ConsumptionPerKilometer * distance)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Model} {Fuel:F2} {TraveledDistance}";
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

                Car car = new Car(model, fuel, consumption);
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
                foreach (var models in cars)
                {
                    if (model == models.Model)
                    {
                        if (!models.IsMove(model, distance))
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                            continue;
                        }
                        else
                        {
                            models.Fuel -= models.ConsumptionPerKilometer * distance;
                            models.TraveledDistance += distance;
                        }
                    }
                }
            }
            //PRINT OUTPUT
            foreach (var currentCar in cars)
            {
                Console.WriteLine(currentCar);
            }
        }
    }
}
