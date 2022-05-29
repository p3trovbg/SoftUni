using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public int Count => Participants.Count;
        public List<Car> Participants;
        public string Name { get; set ; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set ; }
        public int MaxHorsePower { get; set; }


        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate &&
            car.HorsePower <= MaxHorsePower &&
            Capacity > Participants.Count))
            {
                Participants.Add(car);
            }
        }   
        public bool Remove(string license)
        {
            var car = Participants.FirstOrDefault(x => x.LicensePlate == license);
            if (car == null)
            {
                return false;
            }
            else
            {
                Participants.Remove(car);
                return true;
            }
        }
        public Car FindParticipant(string license)
        {
            return Participants.FirstOrDefault(x => x.LicensePlate == license);
        }
        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }
        
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
