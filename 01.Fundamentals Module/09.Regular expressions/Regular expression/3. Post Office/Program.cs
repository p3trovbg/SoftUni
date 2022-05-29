using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            List<string> words = new List<string>();

            Regex capitalLatters = new Regex(@"([\#\$\%\*\&])(?<latters>[A-Z]+)\1");
            Regex asciCode = new Regex(@"(?<asci>\d{2}):(?<length>\d{2})");

            Match capital = capitalLatters.Match(input[0]);
            string latters = capital.Groups["latters"].Value;

            MatchCollection asciAndLength = asciCode.Matches(input[1]);
            string[] text = input[2].Split();

            for (int i = 0; i < latters.Length; i++)
            {
                char currentChar = latters[i];

                foreach (Match value in asciAndLength)
                {
                    int code = int.Parse(value.Groups["asci"].Value);
                    char symbol = (char)code;

                    //Chek for symbol
                    if (symbol != currentChar)
                    {
                        continue;
                    }
                    //Length on words 
                    int length = int.Parse(value.Groups["length"].Value) + 1;

                    for (int j = 0; j < text.Length; j++)
                    {
                        string word = text[j];
                        if (word.Contains(symbol) && word.Length == length)
                        {
                            words.Add(word);
                        }
                    }
                }
            }
            
            foreach (var sb in words.Distinct())
            {
                Console.WriteLine(sb);
            }
        }
    }
}