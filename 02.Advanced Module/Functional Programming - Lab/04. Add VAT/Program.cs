using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x += x * 0.20)
                .ToArray();
            foreach (var digit in numbers)
            {
                Console.WriteLine($"{digit:F2}");
            }
        }
    }
}