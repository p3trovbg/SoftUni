using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using CarManufacturer;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            //Tires
            List<Tire[]> tires = new List<Tire[]>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireSet = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] currentTireSet = new Tire[4];
                int idx = 0;
                for (int i = 0; i < tireSet.Length; i += 2)
                {
                    int year = int.Parse(tireSet[i]);
                    double pressure = double.Parse(tireSet[i + 1]);
                    Tire currentTire = new Tire(year, pressure);
                    currentTireSet[idx] = currentTire;
                    idx++;
                }
                tires.Add(currentTireSet);
            }

            //Engines
            List<Engine> engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);
                engines.Add(currentEngine);
            }

            //Cars
            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                int horsePowers = int.Parse(carInfo[3]);
                double cubics = double.Parse(carInfo[4]);
                Engine engine = engines[int.Parse(carInfo[5])];
                Tire[] tireSet = tires[int.Parse(carInfo[6])];

                Car newCar = new Car(make, model, year, horsePowers, cubics, engine, tireSet);
                cars.Add(newCar);
            }

            Predicate<Car> predicate = car => car.Year >= 2017 &&
                                              car.Engine.HorsePower > 330 &&
                                              car.Tires.Sum(x => x.Pressure) > 9 &&
                                              car.Tires.Sum(x => x.Pressure) < 10;

            foreach (Car car in cars.FindAll(predicate))
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
