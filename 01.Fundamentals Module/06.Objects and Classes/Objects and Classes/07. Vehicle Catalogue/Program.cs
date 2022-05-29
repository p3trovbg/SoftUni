using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Channels;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Truck> currentTruck = new List<Truck>();
            List<Car> currentCar = new List<Car>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] date = input.Split("/", StringSplitOptions.RemoveEmptyEntries);
                string type = date[0];
                string brand = date[1];
                string model = date[2];
                
                if (type == "Car")
                {
                    int horsePower = int.Parse(date[3]);
                    Car cars = new Car(brand, model, horsePower);
                    currentCar.Add(cars);
                }
                else if (type == "Truck")
                {
                    int weight = int.Parse(date[3]);
                    Truck trucks = new Truck(brand, model, weight);
                    currentTruck.Add(trucks);
                }
            }
            //Сортираме по азбучен ред
            List<Truck> sortedTruck = currentTruck.OrderBy(truck => truck.Brand).ToList();
            List<Car> sortedCar = currentCar.OrderBy(car => car.Brand).ToList();

            //Проверяваме дали в листите има нещо , ако да -> принтираме резултата.
            if (currentCar.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car item in sortedCar)
                {
                    Console.WriteLine(item);
                }
            }
            if (currentTruck.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck item in sortedTruck)
                {
                    Console.WriteLine(item); 
                }
            }
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public Car(string brandName, string modelName, int power)
        {
            Brand = brandName;
            Model = modelName;
            HorsePower = power;
        }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public Truck(string brandName, string modelName, int weight)
        {
            Brand = brandName;
            Model = modelName;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }
}

