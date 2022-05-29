using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int limit = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                string operation = "";
                int number = 0;
                if (input == "end")
                {
                    break;

                }

                string[] commands = input.Split();
                if (commands.Length == 2)
                {
                    operation = commands[0];
                    number = int.Parse(commands[1]);
                    myList.Add(number);
                    continue;
                }
                else if (commands.Length == 1)
                {
                    number = int.Parse(commands[0]);
                    for (int i = 0; i < myList.Count; i++)
                    {
                        if (myList[i] + number > limit)
                        {
                            continue;
                        }
                        else
                        {
                            myList[i] += number;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ",myList));
        }
    }
}
