using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalPrice = 0;
            string type = "";
            decimal priceWithoutTaxes = 0;
            decimal taxes = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "special" || input == "regular")
                {
                    type = input;
                    break;
                }
                decimal price = decimal.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                totalPrice += price;
            }
            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            priceWithoutTaxes = totalPrice;
            taxes = totalPrice * 0.20M;
            totalPrice += taxes;


            if (type == "special")
            {
                totalPrice -= totalPrice * 0.10M;
            }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {priceWithoutTaxes:F2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}