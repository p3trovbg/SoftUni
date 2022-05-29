using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Need_for_Speed_III
{
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] dataCar = Console.ReadLine().Split('|');
                string nameCar = dataCar[0];
                int mileage = int.Parse(dataCar[1]);
                int fuel = int.Parse(dataCar[2]);
                if (!cars.ContainsKey(nameCar))
                {
                    cars.Add(nameCar, new Car(mileage, fuel));
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input.Split(" : ");
                string operation = commands[0];
                string nameCar = commands[1];
                switch (operation)
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        int needFuel = int.Parse(commands[3]);
                        if (cars[nameCar].Fuel - needFuel > 0)
                        {
                            Console.WriteLine($"{nameCar} driven for {distance} kilometers. {needFuel} liters of fuel consumed.");
                            cars[nameCar].Fuel -= needFuel;
                            cars[nameCar].Mileage += distance;
                            if (cars[nameCar].Mileage >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {nameCar}!");
                                cars.Remove(nameCar);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        break;
                    case "Refuel":
                        int addedFuel = int.Parse(commands[2]);
                        int avaliableAdded = 0;
                        if (cars[nameCar].Fuel + addedFuel > 75)
                        {
                            avaliableAdded = 75 - cars[nameCar].Fuel;
                            cars[nameCar].Fuel = 75;

                        }
                        else
                        {
                            avaliableAdded = addedFuel;
                            cars[nameCar].Fuel += addedFuel;
                        }
                        Console.WriteLine($"{nameCar} refueled with {avaliableAdded} liters");
                        break;
                    case "Revert":
                        int kilometers = int.Parse(commands[2]);
                        if (cars[nameCar].Mileage - kilometers >= 10000)
                        {
                            Console.WriteLine($"{nameCar} mileage decreased by {kilometers} kilometers");
                            cars[nameCar].Mileage -= kilometers;
                        }
                        else
                        {
                            cars[nameCar].Mileage = 10000;
                        }
                        break;
                }
            }

            cars = cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}
