using System;
using System.Collections.Generic;
using System.Linq;

namespace Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var collection = new List<int>();
            int maxSum = 0;
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(hat + 1);
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else
                {
                    collection.Add(scarf + hat);
                    scarfs.Dequeue();
                    hats.Pop();
                }
            }

            Console.WriteLine($"The most expensive set is: {collection.Max()}");
            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
