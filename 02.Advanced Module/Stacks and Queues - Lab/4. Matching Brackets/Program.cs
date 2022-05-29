using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            var myStack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    myStack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int index = myStack.Pop();
                    Console.WriteLine(expression.Substring(index, i - index + 1));
                }
            }
        }
    }
}
