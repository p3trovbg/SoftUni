using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {

            var myList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
           

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }

                string[] commands = input.Split();
                string operation = commands[0];

                if (operation == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex > myList.Count)
                    {
                        endIndex = myList.Count- 1;
                    }

                    myList[1].Substring(startIndex, endIndex);

                }

            }
        }
    }
}
