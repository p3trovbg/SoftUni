using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            string text = Console.ReadLine();
            MatchCollection result = Regex.Matches(text, pattern);

            foreach (Match names in result)
            {
                Console.Write($"{names.Value} ");

            }
        }
    }
}