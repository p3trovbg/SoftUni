using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var splitter = new string[] { " ? " };
            //t ? t ? t ? 4 : 1 : 2 : 3	4	(t ? (t ? (t ? 4 : 1) : 2) : 3)
            var expression = Console.ReadLine()
                .Split(splitter, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            var elements = expression[expression.Length - 1].Split(" : ").Select(int.Parse).ToArray();
            var queue = new Queue<int>();
            var stack = new Stack<string>();
            for (int i = 0; i < expression.Length - 1; i++)
            {
                stack.Push(expression[i]);
            }

            foreach (var element in elements)
            {
                queue.Enqueue(element);
            }

            var result = false;
            var max = 0;

            var idx = 0;
           while(stack.Count > 0 && queue.Count > 0)
            {
                var boolean = stack.Pop();
                if(idx > 0)
                {
                    var lastValue = queue.Dequeue();
                    if (max > lastValue && boolean == "t")
                    {
                        continue;
                    }
                    else
                    {
                        max = lastValue;
                    }
                    continue;
                }

                var firstValue = queue.Dequeue();
                var secondValue = queue.Dequeue();
                idx++;
                if(firstValue > secondValue && boolean == "t")
                {
                    max = firstValue;
                }
                else
                {
                    max = secondValue;
                }
            }

            Console.WriteLine(max);

        }
    }
}
