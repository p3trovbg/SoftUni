using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sequnce = Console.ReadLine()
                .Split();

            var count = new Dictionary<string, int>();

            foreach (var item in sequnce)
            {
                string wordLow = item.ToLower();
                if (count.ContainsKey(wordLow))
                {
                    count[wordLow]++;
                }
                else
                {
                    count.Add(wordLow, 1);
                }
            }

            foreach (var word in count)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}
