using System;

namespace _05._Combinations_without_Repetition
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

        private static void GenCombinationsWithoutRepetition(int fIdx, int sIdx)
        {
            if (fIdx >= k)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = sIdx; i < elements.Length; i++)
            {
                combinations[fIdx] = elements[i];
                GenCombinationsWithoutRepetition(fIdx + 1, i + 1);
            }
        }
    }
}
