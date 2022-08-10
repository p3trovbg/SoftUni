using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine()
                .Split(" ")
                .Reverse()
                .ToArray();
            var myStack = new Stack<string>(expression);
            int result = 0;
            while (myStack.Count > 1)
            {
                int firstDigit = int.Parse(myStack.Pop());
                char operation = char.Parse(myStack.Pop());
                int secondDigit = int.Parse(myStack.Pop());

                if (operation == '-')
                {
                    result = firstDigit - secondDigit;
                    myStack.Push(result.ToString());

                }
                else
                {
                    result = firstDigit + secondDigit;
                    myStack.Push(result.ToString());
                }
            }

            Console.WriteLine(myStack.Pop());

        }
    }
}
