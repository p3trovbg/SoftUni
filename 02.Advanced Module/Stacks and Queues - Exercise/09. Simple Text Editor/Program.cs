using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var myStack = new Stack<string>();
            var sb = new StringBuilder();
            myStack.Push(sb.ToString());

            for (int i = 0; i < counter; i++)
            {
                string[] commands = Console.ReadLine().Split();
                int operation = int.Parse(commands[0]);

                switch (operation)
                {
                    case 1:
                        sb.Append(commands[1]);
                        myStack.Push(sb.ToString());
                        break;

                    case 2:
                        int counts = int.Parse(commands[1]);
                        sb.Remove(sb.Length - counts, counts);
                        myStack.Push(sb.ToString());
                        break;

                    case 3:
                       int idx = int.Parse(commands[1]);
                       Console.WriteLine(sb[idx - 1]);
                       break;

                    case 4:
                        myStack.Pop();
                        sb.Clear();
                        sb.Append(myStack.Peek());
                        break;
                }
            }
        }
    }
}
