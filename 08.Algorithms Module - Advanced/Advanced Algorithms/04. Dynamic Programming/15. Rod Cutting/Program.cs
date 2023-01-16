using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._Rod_Cutting
{
    public class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int length = int.Parse(Console.ReadLine());

            var cash = new int[prices.Length];
            var combos = new int[prices.Length];

            var bestPrice = RodCutting(length, prices, cash, combos);

            var parts = new List<int>();

            while (length != 0)
            {
                var prev = combos[length];
                parts.Add(prev);
                length -= prev;
            }

            Console.WriteLine(bestPrice);
            Console.WriteLine(String.Join(" ", parts));
        }

        private static int RodCutting(int length, int[] prices, int[] cash, int[] combos)
        {
            if(length == 0)
            {
                return 0;
            }

            if (cash[length] > 0)
            {
                return cash[length];
            }

            var bestPrice = prices[length];
            var bestCombo = length;

            for (int i = 1; i < length - 1; i++)
            {
                var currentPrice = prices[i] + RodCutting(length - i, prices, cash, combos);

                if(currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                    bestCombo = i;
                }
            }

            combos[length] = bestCombo;
            cash[length] = bestPrice;
            return bestPrice;
        }
    }
}
