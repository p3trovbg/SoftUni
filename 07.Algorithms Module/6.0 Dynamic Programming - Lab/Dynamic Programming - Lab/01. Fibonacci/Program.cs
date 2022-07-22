using System;
using System.Collections.Generic;

namespace _01._Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> fibonaccies;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            fibonaccies = new Dictionary<int, long>();

            var result = GetFibonacci(n);

            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if (fibonaccies.ContainsKey(n))
            {
                return fibonaccies[n];
            }

            if (n <= 2)
            {
                return 1;
            }

            var result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            fibonaccies[n] = result;

            return result;
        }
    }
}
