using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            int n = int.Parse(Console.ReadLine());
            Func<int, int, bool> func = (i, i1) => i % i1 == 0;
            var selectedNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (!func(number, n))
                {
                    selectedNumbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", selectedNumbers));
        }
    }
}
