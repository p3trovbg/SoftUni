using System;
using System.Diagnostics.CodeAnalysis;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            long thirdNumber = long.Parse(Console.ReadLine());
            Console.WriteLine(Result(firstNumber, secondNumber, thirdNumber));
        }

        static long Result(long first, long second, long third)
        {
            long sum = first + second;
            sum -= third;
            return sum;
        }
    }
}
