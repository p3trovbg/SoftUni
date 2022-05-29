using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int claimedPoints = 0;
            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int first = firstBox.Peek();
                int second = secondBox.Peek();
                int sum = first + second;
                if (sum % 2 == 0)
                {
                    claimedPoints += first + second;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedPoints >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedPoints}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedPoints}");
            }
        }
    }
}
