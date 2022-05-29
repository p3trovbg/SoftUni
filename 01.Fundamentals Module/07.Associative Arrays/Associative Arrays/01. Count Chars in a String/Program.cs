using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
                
            var countChars = new Dictionary<string, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = (text[i]);
                if (currentChar == ' ')
                {
                    continue;
                }

                if (countChars.ContainsKey(currentChar.ToString()))
                {
                    countChars[currentChar.ToString()]++; 
                }
                else
                {
                    countChars.Add(currentChar.ToString(), 1);
                }
            }

            foreach (var chars in countChars)
            {
                Console.WriteLine($"{chars.Key} -> {chars.Value}");
            }
        }
    }
}
