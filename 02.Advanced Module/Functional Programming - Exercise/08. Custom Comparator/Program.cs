using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> comparator = (firstNumber, secondNumber) =>
                (firstNumber % 2 == 0 && secondNumber % 2 != 0) ? -1 : 
                (firstNumber % 2 != 0 && secondNumber % 2 == 0) ? 1 : 
                firstNumber.CompareTo(secondNumber);

            Array.Sort<int>(numbers, new Comparison<int>(comparator));

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
