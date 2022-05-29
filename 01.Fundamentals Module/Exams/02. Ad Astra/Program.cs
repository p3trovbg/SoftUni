using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regData = new Regex(@"([|#])(?<item>[A-Za-z]+\s?[A-Za-z]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1");
            MatchCollection days = regData.Matches(text);
            int totalCalories = 0;
            foreach (Match day in days)
            {
                totalCalories += int.Parse(day.Groups["calories"].Value);
            }
            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foreach (Match data in days)
            {
                Console.WriteLine($"Item: {data.Groups["item"].Value}, Best before: {data.Groups["date"].Value}, Nutrition: {data.Groups["calories"].Value}");
            }
        }
    }
}