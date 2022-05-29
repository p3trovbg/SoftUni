using System;
using System.Collections.Generic;

namespace MyTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            for (int i = 1; i < 5; i++)
            {
                queue.Enqueue(i * 10);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
