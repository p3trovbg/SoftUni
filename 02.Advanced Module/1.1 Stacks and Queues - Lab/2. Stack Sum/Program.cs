using System;
using System.Collections.Generic;
using System.Linq;
namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var myStack = new Stack<int>(numbers);
            
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "end")
                {
                    break;
                }

                string[] operations = input.Split(" ");
                if (operations[0] == "add")
                {
                    myStack.Push(int.Parse(operations[1]));
                    myStack.Push(int.Parse(operations[2]));
                }
                else
                {
                    int count = int.Parse(operations[1]);
                    if (myStack.Count - count >= 1)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            myStack.Pop();
                        }
                    }
                }
            }
            int sum = myStack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
