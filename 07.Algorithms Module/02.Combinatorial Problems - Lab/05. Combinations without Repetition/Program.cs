using System;

namespace _05._Combinations_without_Repetition
{ 
    class Program
    {
        private static int k;
        private static string[] combinations;
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            k = int.Parse(Console.ReadLine());
            combinations = new string[k];

            GenCombinations(0, 0);
        }

        private static void GenCombinations(int firstIdx, int secondIdx)
        {
            if(combinations.Length <= firstIdx)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = secondIdx; i < elements.Length; i++)
            {
                combinations[firstIdx] = elements[i];
                GenCombinations(firstIdx + 1, i + 1);
            }
        }
    }
}
