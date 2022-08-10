using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int count = int.Parse(Console.ReadLine());
            var myQueue = new Queue<string>(names);

            
            while (myQueue.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    myQueue.Enqueue(myQueue.Dequeue());
                }

                Console.WriteLine($"Removed {myQueue.Dequeue()}");
            }

            Console.WriteLine($"Last is {myQueue.Dequeue()}");
        }
    }
}
