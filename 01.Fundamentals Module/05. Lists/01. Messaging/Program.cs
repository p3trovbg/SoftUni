using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            StringBuilder text = new StringBuilder();
            text.Append(Console.ReadLine());
            string result = null;
            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                string element = numbers[i].ToString();
                for (int j = 0; j < element.Length; j++)
                {
                    sum += int.Parse(element[j].ToString());
                }

                if (sum > text.Length)
                {
                    sum -= text.Length;
                    result += (text[sum].ToString());
                    text.Remove(sum, 1);
                }
                else
                {
                    result += (text[sum].ToString());
                    text.Remove(sum, 1);
                }
            }

            Console.WriteLine(result);
        }
    }
}
