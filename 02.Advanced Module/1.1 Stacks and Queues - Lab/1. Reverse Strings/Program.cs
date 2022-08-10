using System;
using System.Collections.Generic;
namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var myStack = new Stack<char>();
            for (int i = 0; i < text.Length; i++)
            {
                myStack.Push(text[i]);
            }

            while (myStack.Count > 0)
            {
                Console.Write($"{myStack.Pop()}");
            }
        }
    }
}
