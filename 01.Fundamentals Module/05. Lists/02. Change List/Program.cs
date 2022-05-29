using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = Console.ReadLine()
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
                string operation = commands[0];
                int number = int.Parse(commands[1]);
                if (operation == "Delete")
                {
                    myList.RemoveAll(number.Equals);
                }
                else if (operation == "Insert")
                {
                    int newNumber = int.Parse(commands[2]);
                    myList.Insert(newNumber, number);
                }
            }

            Console.WriteLine(string.Join(" ", myList));

        }
    }
}
