using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var counter = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!counter.ContainsKey(text[i]))
                {
                    counter.Add(text[i], 0);
                }

                counter[text[i]]++;
            }

            counter = counter.OrderBy(x => x.Key).ToDictionary(x => x.Key,  x => x.Value);
            foreach (var character in counter)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
