using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int limit = numbers.Count / 2;

            for (int i = 0; i < limit; i++)
            {
                int currentIndex = 1;
                numbers[i] += numbers[numbers.Count - currentIndex];
                int index = numbers.IndexOf(numbers[numbers.Count - currentIndex]);
                numbers.RemoveAt(index);
                currentIndex++;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}