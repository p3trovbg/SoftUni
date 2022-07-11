using System;

namespace _04._Variations_with_Repetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        private static int k;
        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            used = new bool[elements.Length];

            k = int.Parse(Console.ReadLine());
            variations = new string[k];

            GenVariationsWithRepetitions(0);
        }

        private static void GenVariationsWithRepetitions(int idx)
        {
            if(idx >= k)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[idx] = elements[i];
                GenVariationsWithRepetitions(idx + 1);
            }
        }
    }
}
