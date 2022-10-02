using System;
using System.Collections.Generic;
using System.Linq;

namespace _17._Longest_Increasing_Subsequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            var len = new int[numbers.Length];
            var prev = new int[numbers.Length];
            var bestLength = 0;
            var bestIdx = 0;

            for (int currentElementIdx = 0; currentElementIdx < numbers.Length; currentElementIdx++)
            {
                var currentElement = numbers[currentElementIdx];
                
                var currentLength = 1;
                var currentPrev = -1;
                

                for (int prevIdx = currentElementIdx - 1; prevIdx >= 0; prevIdx--)
                {
                    var previousElement = numbers[prevIdx];
                    var previousLength = len[prevIdx] + 1;

                    if (currentElement > previousElement &&
                       currentLength <= previousLength)
                    {
                        currentLength = previousLength;
                        currentPrev = prevIdx;
                    }
                }

                len[currentElementIdx] = currentLength;
                prev[currentElementIdx] = currentPrev; 

                if(currentLength > bestLength)
                {
                    bestLength = currentLength;
                    bestIdx = currentElementIdx;
                }
            }

            var path = new Stack<int>();

            while (bestIdx != -1)
            {
                path.Push(numbers[bestIdx]); ;
                bestIdx = prev[bestIdx];
            }

            Console.WriteLine(String.Join(" ", path));
        }
    }
}
