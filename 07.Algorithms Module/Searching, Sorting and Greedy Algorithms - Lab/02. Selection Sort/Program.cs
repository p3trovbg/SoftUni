using System;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var result = _Selection_Sort(input);
            Console.WriteLine(String.Join(" ", result));
        }

        private static int[] _Selection_Sort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] > input[j])
                    {
                        Swap(input, i, j);
                    }
                }
            }

            return input;
        }

        private static void Swap(int[] input, int i, int j)
        {
            var temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
    }
}
