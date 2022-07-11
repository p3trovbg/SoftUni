using System;

namespace _03._Variations_without_Repetition
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

            GenVariationsWithoutRepetitions(0);
        }

        private static void GenVariationsWithoutRepetitions(int idx)
        {
            if(idx >= k)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[idx] = elements[i];
                    GenVariationsWithoutRepetitions(idx + 1);
                    used[i] = false;
                }
            }
        }
    }
}
