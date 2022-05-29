using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
           
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Engine currentEngine = new Engine(engineSpeed, enginePower);
                Cargo currentCargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];
                int idx = 0;
                for (int j = 5; j < carInfo.Length; j += 2)
                {
                    double pressure = double.Parse(carInfo[j]);
                    int tireYear = int.Parse(carInfo[j + 1]);
                    Tire currentTire = new Tire(tireYear, pressure);
                    tires[idx] = currentTire;
                    idx++;
                }

                cars.Add(new Car(model, currentEngine, currentCargo, tires));
            }
            //•	"fragile" - print all cars whose cargo is "fragile" with a tire, whose pressure is < 1
            //    •	"flamable" - print all of the cars, whose cargo is "flamable" and have engine power > 250

            string typeCargo = Console.ReadLine();
            Predicate<Car> predicate = null;
            if (typeCargo == "fragile")
            {
                predicate = car => car.Cargo.CargoType == typeCargo && car.Tire.Any(t => t.Pressure < 1);
            }
            else if (typeCargo == "flammable")
            {
                predicate = car => car.Cargo.CargoType == typeCargo && car.Engine.EnginePower > 250;
            }

            foreach (var car in cars.FindAll(predicate))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
