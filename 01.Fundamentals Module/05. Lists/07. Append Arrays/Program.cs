using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split("|");

            List<string> myList = new List<string>(numbers.Length);
           
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                string[] elements = numbers[i].Split(' ',StringSplitOptions.RemoveEmptyEntries);
                myList.AddRange(elements);
            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
