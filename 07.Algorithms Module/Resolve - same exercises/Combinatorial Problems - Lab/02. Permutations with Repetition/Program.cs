using System;
using System.Collections.Generic;

namespace _02._Permutations_with_Repetition
{
    public class Program
    {
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            GenPermutationsWithRepetition(0);
        }

        private static void GenPermutationsWithRepetition(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            GenPermutationsWithRepetition(idx + 1);

            var used = new HashSet<string> { elements[idx] };
            for (int i = idx + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(i, idx);
                    GenPermutationsWithRepetition(idx + 1);
                    Swap(i, idx);

                    used.Add(elements[i]);
                }
            }
        }


        private static void Swap(int firstIdx, int secondIdx)
        {
            var temp = elements[firstIdx];
            elements[firstIdx] = elements[secondIdx];
            elements[secondIdx] = temp;
        }
    }
}
