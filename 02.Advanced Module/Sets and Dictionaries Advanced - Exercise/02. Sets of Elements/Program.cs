using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> digits = new List<int>();
            var uniqueNumbers = new HashSet<int>();
            for (int j = 0; j < numbers[0] + numbers[1]; j++)
            {
                int currDigit = int.Parse(Console.ReadLine());
                if (!digits.Contains(currDigit))
                {
                    digits.Add(currDigit);
                }
                else
                {
                    uniqueNumbers.Add(currDigit);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueNumbers));
        }
    }
}
