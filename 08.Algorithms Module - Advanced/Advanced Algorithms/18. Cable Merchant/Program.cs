using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _18._Cable_Merchant
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var prices = new List<int>();

            prices.Add(0);
            prices.AddRange(input);

            var memories = new int[prices.Count];
            int connectorPrice = int.Parse(Console.ReadLine());
            RodCutting(prices.Count - 1, prices, memories, connectorPrice);

            Console.WriteLine(String.Join(" ", memories.Skip(1)));
        }

        private static int RodCutting(int length, List<int> prices, int[] memories, int connectorPrice)
        {
            if (length == 0)
            {
                return 0;
            }

            if (memories[length] != 0)
            {
                return memories[length];
            }

            var bestPrice = prices[length];

            for (int idx = length - 1; idx > 0; idx--)
            {
                var currentPrice 
                    = prices[idx] + RodCutting(length - idx, prices, memories, connectorPrice) - 2 * connectorPrice;

                if(currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                }
            }

            memories[length] = bestPrice;
            return bestPrice;
        }
    }
}
