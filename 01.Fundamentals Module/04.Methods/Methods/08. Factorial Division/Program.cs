using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            if (secondNumber == 0)
            {
                return;
            }
            Console.WriteLine($"{(decimal)Result(firstNumber) / Result(secondNumber):f2}");
        }

        static decimal Result(long first)
        {

            decimal originalFirst = first;
            for (long i = first - 1; i >= 1; i--)
            {
                originalFirst = originalFirst * i;
            }

            return originalFirst;
        }
    }
}
