using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _09.Word_count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(@"words.txt");
            string[] text = File.ReadAllLines(@"text.txt");

            var wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }

            foreach (var line in text)
            {
                string[] wordParts = line.Split(" ,-!.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < wordParts.Length; i++)
                {
                    string currentWord = wordParts[i].ToLower();
                    if (wordsCount.ContainsKey(currentWord))
                    {
                        wordsCount[currentWord]++;
                    }
                }
            }

            foreach (var word in wordsCount.OrderByDescending(x => x.Value))
            {
                string line = $"{word.Key} - {word.Value} {Environment.NewLine}";
                File.AppendAllText(@"actualResult.txt", line);
            }
        }
    }
}
