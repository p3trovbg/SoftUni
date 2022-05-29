using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], bool> predicate = (i, i1) =>
            {
                for (int j = 0; j < i1.Length; j++)
                {
                    int currentDivider = i1[j];
                    if (i % currentDivider != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

                List<int> selectedNumbers = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                int currentNumber = i;
                if (predicate(currentNumber, dividers))
                {
                    selectedNumbers.Add(currentNumber);
                }
            }

            Console.WriteLine(string.Join(" ", selectedNumbers));
        }
    }
}
