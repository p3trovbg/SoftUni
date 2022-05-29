﻿using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string prod = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double result = TotalPrice(prod, quantity);

            Console.WriteLine($"{result:f2}");
        }
        static double TotalPrice(string product, int quantity)
        {
            double price = 0;
            switch (product)
            {
                case "coffee":
                    price = 1.50;                   
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;               
            }
            return price * quantity;
        }
    }
}
