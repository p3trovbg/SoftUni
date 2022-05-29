using System;

namespace _01._Day_of_Week
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

           if(day < 1 || day > 7)
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
