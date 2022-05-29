using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Transactions;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool flag = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] commands = input.Split();
                string operation = commands[0];
                if (operation == "Add" || 
                    operation == "Remove" || 
                    operation == "RemoveAt" ||
                    operation == "Insert")
                {
                    flag = true;
                    int item = int.Parse(commands[1]);
                    if (operation == "Add")
                    {
                        myList.Add(item);
                    }
                    else if (operation == "Remove")
                    {
                        myList.Remove(item);
                    }
                    else if (operation == "RemoveAt")
                    {
                        myList.RemoveAt(item);
                    }
                    else if (operation == "Insert")
                    {
                        int newItem = int.Parse(commands[2]);
                        myList.Insert(newItem, item);
                    }
                }
                
                if (operation == "Contains")
                {
                    int number = int.Parse(commands[1]);
                    if (myList.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (operation == "PrintEven")
                {
                    Console.WriteLine(string.Join(" ", myList.Where(x => x % 2 == 0)));
                }
                else if (operation == "PrintOdd")
                {
                    Console.WriteLine(string.Join(" ", myList.Where(x => x % 2 != 0)));
                }
                else if (operation == "GetSum")
                {
                    Console.WriteLine(string.Join(" ", myList.Sum()));
                }
                else if (operation == "Filter")
                {
                    string condition = commands[1];
                    int number = int.Parse(commands[2]);
                    //'<', '>', ">=", "<=".
                    if (condition == "<")
                    {
                        Console.WriteLine(string.Join(" ", myList.Where(x => x < number)));
                    }
                    else if (condition == ">")
                    {
                        Console.WriteLine(string.Join(" ", myList.Where(x => x > number)));
                    }
                    else if (condition == ">=")
                    {
                        Console.WriteLine(string.Join(" ", myList.Where(x => x >= number)));
                    }
                    else if (condition == "<=")
                    {
                        Console.WriteLine(string.Join(" ", myList.Where(x => x <= number)));
                    }

                }
            }

            if (flag)
            {
                Console.WriteLine(string.Join(" ", myList));
            }
        }
    }
}
