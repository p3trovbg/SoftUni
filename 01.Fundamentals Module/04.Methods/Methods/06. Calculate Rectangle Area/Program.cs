using System;
using System.ComponentModel;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            long width = long.Parse(Console.ReadLine());
            long weight = long.Parse(Console.ReadLine());

            Console.WriteLine(Result(width, weight));
        }

        static long Result(long a, long b)
        {
            return a * b;
        }
    }
}
