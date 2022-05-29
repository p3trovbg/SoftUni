using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Dictionary<string, double>();
            var productQuantity = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }

                string[] data = input.Split();
                string currentProduct = data[0];
                double price = double.Parse(data[1]);
                int quantity = int.Parse(data[2]);

                if (!product.ContainsKey(currentProduct))
                {
                    product.Add(currentProduct, price);
                    productQuantity.Add(currentProduct, quantity);
                }
                else
                {
                    product[currentProduct] = price;
                    productQuantity[currentProduct] += quantity;
                }
            }

            var result = product
                .ToDictionary(x => x.Key, x => x.Value * productQuantity[x.Key]);
            foreach (var products in result)
            {
                Console.WriteLine($"{products.Key} -> {products.Value:F2}");
            }
        }
    }
}