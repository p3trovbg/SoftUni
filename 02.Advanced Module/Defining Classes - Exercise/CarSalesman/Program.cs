using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < count; i++)
            {
                bool flag = false;
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                Engine newEngine = new Engine(model, power);
                OptionalEngine(engineInfo, newEngine, flag);

                engines.Add(newEngine);
            }

            List<Car> cars = new List<Car>();
            count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                bool flag = false;
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engine = carInfo[1];
                Engine currentEngine = engines.FirstOrDefault(x => x.Model == engine);
                Car newCar = new Car(model, currentEngine);
                OptionalCar(carInfo, newCar, flag);
                cars.Add(newCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void OptionalEngine(string[] engineInfo, Engine newEngine, bool flag)
        {
            int digit;
            if (engineInfo.Length > 2)
            {
                if (int.TryParse(engineInfo[2], out digit))
                {
                    newEngine.Displacement = engineInfo[2];
                }
                else
                {
                    newEngine.Efficiency = engineInfo[2];
                    flag = true;
                }
            }

            if (engineInfo.Length > 3 && !flag)
            {
                newEngine.Efficiency = engineInfo[3];
            }
        }

        private static void OptionalCar(string[] carInfo, Car newCar, bool flag)
        {
            int digit;
            if (carInfo.Length > 2)
            {
                if (int.TryParse(carInfo[2], out digit))
                {
                    newCar.Weight = carInfo[2];
                }
                else
                {
                    newCar.Color = carInfo[2];
                    flag = true;
                }
            }

            if (carInfo.Length > 3 && !flag)
            {
                newCar.Color = carInfo[3];
            }
        }
    }
}
