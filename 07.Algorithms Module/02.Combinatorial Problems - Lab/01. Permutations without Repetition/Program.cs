using System;

namespace _01._Permutations_without_Repetition
{
    class Program
    {
        private static string[] elements;
        private static int totalPermutations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Permute(0);
            Console.WriteLine(totalPermutations);
        }

        private static void Permute(int idx)
        {
            if (idx >= elements.Length)
            {
                totalPermutations++;
                Console.WriteLine(string.Join(string.Empty, elements));
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < 2; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var firstElement = elements[first];
            elements[first] = elements[second];
            elements[second] = firstElement;
        }
    }
}
