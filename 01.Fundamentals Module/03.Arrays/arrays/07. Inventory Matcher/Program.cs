using System;
using System.Linq;

namespace _07._Inventory_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine()
                .Split()
                .ToArray();
            long[] pieces = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();
            decimal[] sums = Console.ReadLine()
                .Split()
                .Select(decimal.Parse)
                .ToArray();
            bool flag = false;
            while (!false)
            {
                string input = Console.ReadLine();
                if (input == "done")
                {
                    flag = true;
                    break;
                }

                for (int i = 0; i < products.Length; i++)
                {
                    if (input == products[i])
                    {
                        Console.WriteLine($"{input} costs: {sums[i]}; Available quantity: {pieces[i]}");
                    }
                }
            }
        }
    }
}