using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex reg = new Regex(@"(\=|\/)(?<text>[A-Z][A-Za-z]{2,})\1");

            MatchCollection destiantions = reg.Matches(text);
            List<string> myList = new List<string>();
            int travelPoints = 0;
            foreach (Match destiantion in destiantions)
                {
                    myList.Add(destiantion.Groups["text"].Value);
                    travelPoints += destiantion.Groups["text"].Value.Length;
                }

            Console.WriteLine($"Destinations: {string.Join(", ", myList)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
