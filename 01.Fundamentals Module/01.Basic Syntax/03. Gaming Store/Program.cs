using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double staticBalance = balance;
            string input = Console.ReadLine();
            double price = 0;
            double totalSum = 0;
            bool flag = true;
            bool flagSecond = false;
            while (input != "Game Time")
            {
                if (input == "OutFall 4")
                {
                    price = 39.99;
                }
                else if (input == "CS: OG")
                {
                    price = 15.99;
                }
                else if (input == "Zplinter Zell")
                {
                    price = 19.99;
                }
                else if (input == "Honored 2")
                {
                    price = 59.99;
                }
                else if (input == "RoverWatch")
                {
                    price = 29.99;
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    flagSecond = true;
                }
              
                if (balance < price)
                {
                    Console.WriteLine("Too Expensive");
                }
                else if (balance >= price && !flagSecond)
                {
                    totalSum += price; 
                    balance -=price;
                    Console.WriteLine($"Bought {input}");                   
                }
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    flag = false;
                    break;
                }
                flagSecond = false;
                input = Console.ReadLine();               
            }
            if (flag)
            {
                Console.Write($"Total spent: ${totalSum:f2}. ");
                Console.WriteLine($"Remaining: ${staticBalance - totalSum:f2}");
            }   
        }
    }
}
