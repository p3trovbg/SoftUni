using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Words_count
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"C:\Users\Petrov\Desktop\Advanced Module\Streams\03.Word count\words.txt");
            string input = sr.ReadLine();
            string[] words = input.Split();
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                dictionary.Add(word, 1);
            }
            using StreamReader text = new StreamReader(@"C:\Users\Petrov\Desktop\Advanced Module\Streams\03.Word count\input.txt");
            while (!text.EndOfStream)
            {
                string[] line = text.ReadLine().Split();
                foreach (var word in line)
                {
                    if (dictionary.ContainsKey(word))
                    {
                        dictionary[word]++;
                    }
                }
            }

            using StreamWriter sw = new StreamWriter(@"C:\Users\Petrov\Desktop\Advanced Module\Streams\03.Word count\Output.txt");
            dictionary = dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in dictionary)
            {
                string line = $"{item.Key} - {item.Value}";
                sw.WriteLine(line);
            }
        }
    }
}
