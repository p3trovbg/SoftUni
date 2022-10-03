using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Best_Team
{
    public class Program
    {
        static void Main(string[] args)
        {
            var soldiers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var lis = LongestIncreasingSubsequence(soldiers);
            var lds = LongestIncreasingSubsequence(soldiers.Reverse().ToArray());

            if (lis.Count() > lds.Count())
            {
                Console.WriteLine(String.Join(" ", lis));
            }
            else
            {
                Console.WriteLine(String.Join(" ", lds.Reverse()));
            }
        }

        private static IEnumerable<int> LongestIncreasingSubsequence(int[] soldiers)
        {
            Stack<int> stack = new Stack<int>();
            var len = new int[soldiers.Length];
            var prev = new int[soldiers.Length];
            var bestIdx = 0;
            var bestLen = 0;

            for (int currentIdx = 0; currentIdx < soldiers.Length; currentIdx++)
            {
                var currentSoldier = soldiers[currentIdx];
                var currentPrev = -1;
                var currentLen = 1;

                for (int previousIdx = currentIdx - 1; previousIdx >= 0; previousIdx--)
                {
                    var previousSoldier = soldiers[previousIdx];
                    var previousLength = len[previousIdx] + 1;

                    if (currentSoldier > previousSoldier &&
                        currentLen <= previousLength)
                    {
                        currentLen = previousLength;
                        currentPrev = previousIdx;
                    }
                }

                len[currentIdx] = currentLen;
                prev[currentIdx] = currentPrev;

                if (bestLen < currentLen)
                {
                    bestLen = currentLen;
                    bestIdx = currentIdx;
                }
            }

            while (bestIdx != -1)
            {
                stack.Push(soldiers[bestIdx]);
                bestIdx = prev[bestIdx];
            }

            return stack;
        }
    }
}
