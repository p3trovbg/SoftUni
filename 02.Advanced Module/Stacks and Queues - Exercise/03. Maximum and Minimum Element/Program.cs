using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var myStack = new Stack<int>();
            int element = 0;
            for (int i = 0; i < counter; i++)
            {
                bool flag = false;
                int[] commands = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int operation = commands[0];
                if (commands.Length == 1)
                {
                    flag = true;
                }
                if (commands.Length >= 1)
                {
                    if (flag)
                    {
                        element = commands[0];
                    }
                    else
                    {
                        element = commands[1];
                    }
                    switch (operation)
                    {
                        case 1:
                            myStack.Push(element);
                            break;
                        case 2:
                            if (myStack.Count >= 1)
                            {
                                myStack.Pop();
                            }
                            break;
                        case 3:
                            if (myStack.Count >= 1)
                            {
                                Console.WriteLine(myStack.Max());
                            }
                            break;
                        case 4:
                            if (myStack.Count >= 1)
                            {
                                Console.WriteLine(myStack.Min());
                            }
                            break;
                    }
                }

            }

            myStack.ToArray();
            Console.WriteLine(string.Join(", ", myStack));
        }
    }
}
