using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            long degree = long.Parse(Console.ReadLine());

            long result = MathPower(number, degree);
            Console.WriteLine(result);
        }

        static long MathPower(long num, long degree)
        {
            return Math.Pow(num, degree);
        }
    }
}