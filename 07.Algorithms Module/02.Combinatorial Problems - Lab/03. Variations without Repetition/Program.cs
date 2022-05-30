using System;

namespace _03._Variations_without_Repetition
{
    class Program
    {
        private static int k;
        private static string[] variations;
        private static string[] elements;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            used = new bool[elements.Length];
            k = int.Parse(Console.ReadLine());
            variations = new string[k];

            Variations(0);
        }

        private static void Variations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if(!used[i])
                {
                    used[i] = true;
                    variations[idx] = elements[i];
                    Variations(idx + 1);
                    used[i] = false;
                }
            }
        }
    }
}
