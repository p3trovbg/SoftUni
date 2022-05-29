using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            long quantity = long.Parse(Console.ReadLine());
            Console.WriteLine($"{Sum(product, quantity):f2}");
        }

        static long Sum(string product, long quantity)
        {
            long sum = 0;
            switch (product)
            {
                case "coffee":
                    sum = 1.50 * quantity;
                    break;
                case "water":
                    sum = 1 * quantity;
                    break;
                case "coke":
                    sum = 1.40 * quantity;
                    break;
                case "snacks":
                    sum = 2 * quantity;
                    break;
            }


            return sum;
        }
    }
}
