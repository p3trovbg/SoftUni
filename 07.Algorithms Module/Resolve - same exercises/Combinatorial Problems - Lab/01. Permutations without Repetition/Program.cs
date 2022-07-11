using System;

namespace _01._Permutations_without_Repetition
{
    public class Program
    {
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            GenPermutationsWithoutRepetitions(0);
        }

        private static void GenPermutationsWithoutRepetitions(int idx)
        {
            if(idx >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            GenPermutationsWithoutRepetitions(idx + 1);

            for (int i = idx + 1; i < elements.Length; i++)
            {
                Swap(i, idx);
                GenPermutationsWithoutRepetitions(idx + 1);
                Swap(i, idx);
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
