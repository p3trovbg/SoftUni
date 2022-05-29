using System;
using System.Numerics;

namespace _02._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            BigInteger num = 1;
            for (int i = 2; i <= count; i++)
            {
                num *= i;
            }

            Console.WriteLine(num);

        }
    }
}
