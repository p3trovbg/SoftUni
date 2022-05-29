using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionForKm = double.Parse(carInfo[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumptionForKm, 0));
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                //"Drive {carModel} {amountOfKm}"
                string[] driveInfo = input.Split();
                string carModel = driveInfo[1];
                double amountOfKm = double.Parse(driveInfo[2]);
                Car currentCar = cars.FirstOrDefault(x => x.Model == carModel);
                currentCar.Drive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
