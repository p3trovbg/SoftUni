using System;
using System.Collections.Generic;

namespace _20._Longest_String_Chain
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfStrings = Console.ReadLine().Split();

            var prev = new int[listOfStrings.Length];
            var len = new int[listOfStrings.Length];

            var bestLength = 0;
            var bestIdx = 0;

            for (int currentIdx = 0; currentIdx < listOfStrings.Length; currentIdx++)
            {
                var currentString = listOfStrings[currentIdx];
                var currentLength = 1;
                var currentPrev = -1;

                for (int prevIdx = currentIdx - 1; prevIdx >= 0; prevIdx--)
                {
                    var currentPrevString = listOfStrings[prevIdx];
                    var currentPrevLength = len[prevIdx] + 1;


                    if(currentString.Length > currentPrevString.Length &&
                        currentLength <= currentPrevLength)
                    {
                        currentLength = currentPrevLength;
                        currentPrev = prevIdx;
                    }
                }

                prev[currentIdx] = currentPrev;
                len[currentIdx] = currentLength;

                if(bestLength < currentLength)
                {
                    bestLength = currentLength;
                    bestIdx = currentIdx;
                }
            }

            var lis = new Stack<string>();
            //var lds = new List<string>();
            while (bestIdx != -1)
            {
                lis.Push(listOfStrings[bestIdx]);
                //lds.Add(listOfStrings[bestIdx]);
                bestIdx = prev[bestIdx];
            }

            Console.WriteLine(string.Join(" ", lis));
            //Console.WriteLine(string.Join(" ", lds)); = Longest decreasing subsequnce
        }
    }
}
