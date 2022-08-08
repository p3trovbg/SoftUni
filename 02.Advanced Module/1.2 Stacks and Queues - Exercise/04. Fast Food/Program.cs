using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] ordersForDay = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var myQueue = new Queue<int>(ordersForDay);

            Console.WriteLine(myQueue.Max());
            while (myQueue.Count > 0)
            {
                if (quantityFood >= myQueue.Peek())
                {
                    quantityFood -= myQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: { string.Join(" ", myQueue)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}