using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var result = _Bubble_Sort(input);
            Console.WriteLine(String.Join(" ", result));
        }

        private static int[] _Bubble_Sort(int[] input)
        {
            bool swapped;
            for (int i = 0; i < input.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < input.Length - i - 1; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        var temp = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = temp;
                        swapped = true;
                    }
                }

                if(!swapped)
                {
                    break;
                }
            }

            return input;
        }
    }
}
