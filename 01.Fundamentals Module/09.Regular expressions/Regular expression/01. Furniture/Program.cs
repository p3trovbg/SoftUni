using System;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<product>[A-Z]|[a-z]|[A-z]+)<<(?<price>[\d\.]+)[\!](?<quantity>\d+)\b";
            Console.WriteLine("Bought furniture:");
            double sum = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }

                MatchCollection products = Regex.Matches(input, pattern);

                foreach (Match product in products)
                {
                    double price = double.Parse(product.Groups["price"].Value);
                    int quantity = int.Parse(product.Groups["quantity"].Value);
                    sum += price * quantity;
                    Console.WriteLine(product.Groups["product"].Value);
                }
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
