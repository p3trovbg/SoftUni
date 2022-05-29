using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToList();
            int limit = 3;
            if (numbers.Count < 3)
            {
                limit = numbers.Count;
            }

            for (int i = 0; i < limit; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
