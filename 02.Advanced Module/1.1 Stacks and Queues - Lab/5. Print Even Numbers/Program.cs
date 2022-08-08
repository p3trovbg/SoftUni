using System;
using System.Linq;
using System.Collections.Generic;
namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var myQ = new Queue<int>();

            for (int i = 0; i < digits.Length; i++)
            {
                int digit = digits[i];
                if (digit % 2 == 0)
                {
                    myQ.Enqueue(digit);

                }
            }
            myQ.ToArray();
            Console.WriteLine(string.Join(", ", myQ));
        }
    }
}