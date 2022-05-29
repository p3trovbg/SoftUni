using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace _2._Mirror_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regWords = new Regex(@"([@|#])(?<first>[A-Za-z]{3,})\1{2}(?<second>[A-Za-z]{3,})\1");

            MatchCollection words = regWords.Matches(input);
            if (words.Count <= 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{words.Count} word pairs found!");
            }
            List<string> mirrorWords = new List<string>();
            foreach (Match word in words)
            {
                string first = word.Groups["first"].Value;
                string second = word.Groups["second"].Value;
                if (first.Length == second.Length && ExistMirrorWords(first, second))
                {
                    mirrorWords.Add($"{first} <=> {second}");
                }
            }
            if (mirrorWords.Count > 0)
            {
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }

        private static bool ExistMirrorWords(string first, string second)
        {
            char[] firstWord = first.ToCharArray().Reverse().ToArray();
            char[] secondWord = second.ToCharArray().Reverse().ToArray();
            string reverseWord = string.Join("", firstWord);
            string secondReverse = string.Join("", secondWord);
            if (reverseWord == second && secondReverse == first)
            {
                return true;
            }
            return false;
        }
    }
}