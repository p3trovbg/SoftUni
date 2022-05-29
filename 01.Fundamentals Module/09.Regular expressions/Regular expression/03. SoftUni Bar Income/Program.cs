using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<name>[A-Z][a-z]+)%\<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)\$$";
            double sum = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }

                Match user = Regex.Match(input, pattern);
                if (!user.Success)
                {
                    continue;
                }
                string name = user.Groups["name"].Value;
                    string nameProduct = user.Groups["product"].Value;
                    int quantity = int.Parse(user.Groups["quantity"].Value);
                    double price = double.Parse(user.Groups["price"].Value);
                    double total = quantity * price;
                    Console.WriteLine($"{name}: {nameProduct} - {total:F2}");
                    sum += total;
            }

            Console.WriteLine($"Total income: {sum:F2}");
        }
    }
}
