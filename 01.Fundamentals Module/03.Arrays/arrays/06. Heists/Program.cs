using System;
using System.Linq;

namespace _06._Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long expenses = 0;
            long earnings = 0;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (input[0] == "Jail" && input[1] == "Time")
                {
                    break;
                }
                expenses += long.Parse(input[1]);
                foreach (var items in input[0])
                {
                    if (items == '%')
                    {
                        earnings += numbers[0];
                    }
                    else if (items == '$')
                    {
                        earnings += numbers[1];
                    }
                }
            }
            if (expenses <= earnings)
            {
                earnings -= expenses;
                Console.WriteLine($"Heists will continue. Total earnings: {earnings}.");
            }
            else
            {
                expenses -= earnings;

                Console.WriteLine($"Have to find another job. Lost: {expenses}.");
            }
        }
    }
}
