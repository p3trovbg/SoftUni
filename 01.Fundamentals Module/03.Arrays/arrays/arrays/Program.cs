using System;

namespace WeekOfDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string[] arr = new string[]
            {
              "Monday",
              "Tuesday",
              "Wednesday",
              "Thursday",
              "Friday",
              "Saturday",
              "Sunday"
            };
            day -= 1;
            if (day < 0 || day > 6)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(arr[day]);
            }
        }
    }
}
