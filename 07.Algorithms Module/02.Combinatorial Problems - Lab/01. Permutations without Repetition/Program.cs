using System;
using System.IO;

namespace _01._Permutations_without_Repetition
{
    class Program
    {
        private static StreamWriter writer = new StreamWriter("permutations.txt", true);
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Permute(0);
            writer.Close();
        }

        private static void Permute(int idx)
        {
            if(idx >= elements.Length)
            {
                writer.WriteLine(string.Join(string.Empty, elements));
                Console.WriteLine(string.Join(string.Empty, elements));
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < elements.Length; i++)
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
