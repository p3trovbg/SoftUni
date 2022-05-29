using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = new long[3];

            for (long i = 0; i < numbers.Length; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }

            Console.WriteLine(Result(numbers));
        }
        static long Result (long[] numbers)
        {
            long minValue = numbers.Min();
            return minValue;
        }
    }
}
