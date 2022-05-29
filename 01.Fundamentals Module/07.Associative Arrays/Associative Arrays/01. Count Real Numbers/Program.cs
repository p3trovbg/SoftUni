using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new SortedDictionary<double, int>();
            double[] num = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var currentNumber in num)
            {
                if (numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber]++;
                }
                else
                {
                    numbers.Add(currentNumber, 1);
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
