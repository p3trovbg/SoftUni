using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            // Queue
            var myQueue = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                else if (input == "Paid")
                {
                    while (myQueue.Count > 0)
                    {
                        Console.WriteLine(myQueue.Dequeue());
                    }
                }
                else
                {
                    myQueue.Enqueue(input);
                }
            }
            Console.WriteLine($"{myQueue.Count} people remaining.");
        }
    }
}