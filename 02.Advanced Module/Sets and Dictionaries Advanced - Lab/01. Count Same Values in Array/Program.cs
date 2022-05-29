using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] digits = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var dictionary = new Dictionary<string, int>();
            for (int i = 0; i < digits.Length; i++)
            {
                string currentNumber = digits[i];
                if (!dictionary.ContainsKey(currentNumber))
                {
                    dictionary.Add(currentNumber, 0);
                }
                dictionary[currentNumber]++;
            }
            foreach (var digit in dictionary)
            {
                Console.WriteLine($"{digit.Key} - {digit.Value} times");
            }
        }
    }
}