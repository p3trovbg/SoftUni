using System;

namespace _06._Combinations_with_Repetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] combinations;
        private static int k;
        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            k = int.Parse(Console.ReadLine());
            combinations = new string[k];

            GenCombinationsWithoutRepetition(0, 0);
        }

        private static void GenCombinationsWithoutRepetition(int idx, int secondIdx)
        {
            if (idx >= k)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = secondIdx; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                GenCombinationsWithoutRepetition(idx + 1, i);
            }
        }
    }
}
