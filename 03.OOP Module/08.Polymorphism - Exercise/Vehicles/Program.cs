using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehicles car = null;
            Vehicles truck = null;
            Bus bus = null;
            for (int i = 0; i < 3; i++)
            {
                string[] info = Console.ReadLine().Split();
                string vehicle = info[0];
                double fuelQuantity = double.Parse(info[1]);
                double consumption = double.Parse(info[2]);
                double tankCapacity = double.Parse(info[3]);
                if (fuelQuantity > tankCapacity)
                {
                    fuelQuantity = 0;
                }

                switch (vehicle)
                {
                    case "Car":
                        car = new Car(fuelQuantity, consumption, tankCapacity);
                        break;

                    case "Truck":
                        truck = new Truck(fuelQuantity, consumption, tankCapacity);
                        break;

                    case "Bus":
                        bus = new Bus(fuelQuantity, consumption, tankCapacity);
                        break;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string action = info[0];
                string vehicle = info[1];
                double distance = double.Parse(info[2]);

                switch (action)
                {
                    case "Drive" when vehicle == "Car":
                        car.Drive(distance);
                        break;
                    case "Drive" when vehicle == "Truck":
                        truck.Drive(distance);
                        break;
                    case "Drive":
                    case "DriveEmpty" when vehicle == "Bus":
                        if (action == "DriveEmpty")
                        {
                            bus.IsEmpty = true;
                        }
                        bus.Drive(distance);
                        break;
                    case "Refuel" when vehicle == "Car":
                        car.Refuel(distance);
                        break;
                    case "Refuel" when vehicle == "Truck":
                        truck.Refuel(distance);
                        break;
                    case "Refuel" when vehicle == "Bus":
                        bus.Refuel(distance);
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
