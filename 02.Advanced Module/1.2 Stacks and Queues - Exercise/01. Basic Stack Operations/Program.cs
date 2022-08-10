using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] boxStack = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var digits = new Stack<int>(boxStack);
            int pops = numbers[1];
            int searchDigit = numbers[2];
            for (int i = 0; i < pops; i++)
            {
                digits.Pop();
            }

            if (digits.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (digits.Contains(searchDigit))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(digits.Min());
            }
        }
    }
}
