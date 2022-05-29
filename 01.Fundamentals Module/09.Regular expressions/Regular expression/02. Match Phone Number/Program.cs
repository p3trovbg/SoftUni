using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string phones = Console.ReadLine();
            string pattern = @"(\+359)(\s|-)[2]\2[\d]{3}\2[\d]{4}\b";
            var sb = new StringBuilder();

            MatchCollection collection = Regex.Matches(phones, pattern);

            var result = collection
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}