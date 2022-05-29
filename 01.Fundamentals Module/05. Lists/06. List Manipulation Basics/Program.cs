using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] commands = input.Split();
                string command = commands[0];
                int item = int.Parse(commands[1]);
                if (command == "Add")
                {
                    numbers.Add(item);
                }
                else if (command == "Remove")
                {
                    numbers.Remove(item);
                }
                else if (command == "RemoveAt")
                {
                    numbers.RemoveAt(item);
                }
                else if (command == "Insert")
                {
                    int newItem = int.Parse(commands[2]);
                    numbers.Insert(newItem, item);
                }

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}