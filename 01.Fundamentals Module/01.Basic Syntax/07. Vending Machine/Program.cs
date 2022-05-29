using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            while (input != "Start")
            {
                double coins = double.Parse(input);

                if (coins == 0.1 ||
                    coins == 0.2 ||
                    coins == 0.5 ||
                    coins == 1 ||
                    coins == 2)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine();
            }
            // 2.50 = 0.80 + 1 = 1.80 = 2.50 - 1.80 = 
            double price = 0;
            bool flag = false;
            double totalSum = 0;
            input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Nuts")
                {
                    price = 2;
                }
                else if (input == "Water")
                {
                    price = 0.7;
                }
                else if (input == "Crisps")
                {
                    price = 1.5;
                }
                else if (input == "Soda")
                {
                    price = 0.8;
                }
                else if (input == "Coke")
                {
                    price = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    flag = true;
                }
                totalSum += price;
                if (sum >= totalSum && !flag)
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                }
                if (sum < totalSum)
                {
                    Console.WriteLine("Sorry, not enough money");
                    totalSum -= price;               
                }
                input = Console.ReadLine();
            }          
            if (totalSum > sum)
            {
                Console.WriteLine($"Change: {totalSum - sum:f2}");
            }
            else
            {
                Console.WriteLine($"Change: {sum - totalSum:f2}");
            }

                  
        }
    }
}
