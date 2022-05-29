using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] commands = input.Split();
                string operation = commands[0];

                if (operation == "Add")
                {
                    int number = int.Parse(commands[1]);
                    numbers.Add(number);
                }

                //премахване на индекс 
                else if (operation == "Remove")
                {
                    int number = int.Parse(commands[1]);
                    if (!isValid(number, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(number);
                    ;
                }
                //вмъкване на число
                else if (operation == "Insert")
                {
                    int index = int.Parse(commands[2]);
                    int newNumber = int.Parse(commands[1]);
                    if (!isValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(index, newNumber);
                }

                //Дясно / ляво
                else if (operation == "Shift")
                {
                    string side = commands[1];
                    int count = int.Parse(commands[2]);
                    //Изместване на дясно
                    if (side == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastElement = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastElement);
                        }
                    }
                    //Изместване на ляво
                    else if (side == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstElement = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(firstElement);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool isValid(int number, List<int> numbers)
        {
            return number <= numbers.Count && number >= 0;
        }
    }
}
