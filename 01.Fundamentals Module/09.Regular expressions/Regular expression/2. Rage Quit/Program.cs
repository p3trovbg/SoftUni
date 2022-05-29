using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"((?<text>\D+)(?<digit>\d+))";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);
            var result = new StringBuilder();

            foreach (Match match in matches)
            {
                string temp = match.Groups["text"].Value;
                int repeats = int.Parse(match.Groups["digit"].Value);
                for (int i = 0; i < repeats; i++)
                {
                    result.Append(temp.ToUpper());
                }
            }

            int count = result.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(result);
        }
    }
}