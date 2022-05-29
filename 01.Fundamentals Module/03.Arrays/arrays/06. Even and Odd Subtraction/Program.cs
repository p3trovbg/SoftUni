using System;
using System.Linq;
namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int odd = 0;
            int even = 0;
            for (int i = 0; i < arry.Length; i++)
            {              
                if (arry[i]% 2 == 0)
                {
                    even += arry[i];
                }
                else
                {
                    odd += arry[i];
                }
            }
            int difference = even - odd;
            Console.WriteLine(difference);
        }
    }
}
