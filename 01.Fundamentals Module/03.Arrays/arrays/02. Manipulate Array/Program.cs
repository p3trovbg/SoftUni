using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] exist = new string[input.Length];
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();
                if (command[0] == "Reverse")
                {
                    exist = input.Reverse().ToArray();
                    input = exist;
                }
                else if (command[0] == "Distinct")
                {
                    exist = input.Distinct().ToArray();
                    input = exist;
                }
                else if (command[0] == "Replace")
                {
                    int index = int.Parse(command[1]);
                    input[index] = command[2];
                    exist = input;
                }
            }

            Console.WriteLine(string.Join(", ", input));

        }
    }
}
