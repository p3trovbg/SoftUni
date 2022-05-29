using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");
            var racer = new Dictionary<string, int>();
            
           
            while (true)
            {
                string input = Console.ReadLine();
                string name = string.Empty;
                int sum = 0;

                if (input == "end of race")
                {
                    break;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        sum += input[i] - '0';
                    }
                    else if (char.IsLetter(input[i]))
                    {
                        name += input[i];
                    }
                }
                
                if (racer.ContainsKey(name))
                {
                    racer[name] += sum;
                }
                else
                {
                    if (names.Contains(name))
                    {
                        racer.Add(name, sum);
                    }
                }
            }
            //Order by decending
            var orderRacer = racer.OrderByDescending(x => x.Value);
            //Result
            Result(orderRacer);
        }

        private static void Result(IOrderedEnumerable<KeyValuePair<string, int>> orderRacer)
        {
            int idx = 1;
            foreach (var racer in orderRacer)
            {
                if (idx == 1)
                {
                    Console.WriteLine($"1st place: {racer.Key}");
                }
                else if (idx == 2)
                {
                    Console.WriteLine($"2nd place: {racer.Key}");
                }
                else if (idx == 3)
                {
                    Console.WriteLine($"3rd place: {racer.Key}");
                }
                idx++;
            }
        }
    }
}
