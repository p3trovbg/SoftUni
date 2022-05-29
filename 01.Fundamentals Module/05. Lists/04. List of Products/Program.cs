using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>(n);
            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }
            products.Sort();
            int index = 1;
            foreach (var product in products)
            {
                Console.WriteLine($"{index}.{product}");
                index++;
            }
        }
    }
}