using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count => cars.Count;
        public Parking(int capacity)
        {
            cars = new List<Car>(capacity);
            this.capacity = capacity;
        }
        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                 Car car = cars[i];
                 if (car.RegistrationNumber == registrationNumber)
                 {
                     cars.Remove(car);
                     return $"Successfully removed {registrationNumber}";
                 }
            }
            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            return (cars.Find(x => x.RegistrationNumber == registrationNumber));
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registrationNumber in RegistrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
