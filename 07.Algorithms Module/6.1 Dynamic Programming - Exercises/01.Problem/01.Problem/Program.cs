using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    public class Time
    {
        public Time(double arrival, double departure)
        {
            Arrival = arrival;
            Departure = departure;
        }

        public double Arrival { get; set; }
        public double Departure { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrivalTimes= Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var departureTimes = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var queue = new Queue<Time>();

            for (int i = 1; i < arrivalTimes.Length; i++)
            {
                queue.Enqueue(new Time(arrivalTimes[i], departureTimes[i]));
            }

            var departure = departureTimes[0];
            var removePlatforms = 0;

            while (queue.Count > 0)
            {
                var time = queue.Dequeue();

                if(departure > time.Arrival)
                {
                    removePlatforms += 1;
                }
                else
                {
                    departure = time.Departure;
                }
            }

            Console.WriteLine(removePlatforms);
        }
    }
}
