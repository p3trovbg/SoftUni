using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = ReadDigits();
            int[,] matrix = new int[parameters[0], parameters[1]];

            for (int i = 0; i < parameters[0]; i++)
            {
                int[] digits = ReadDigits();
                for (int j = 0; j < parameters[1]; j++)
                {
                    matrix[i, j] = digits[j];
                }
            }
            int sum = 0;
            int maxSum = int.MinValue;
            int col = 0;
            int row = 0;
            for (int i = 0; i < parameters[0] - 1; i++)
            {
                for (int j = 0; j < parameters[1] - 1; j++)
                {
                    sum = matrix[i, j] +
                          matrix[i, j + 1] +
                          matrix[i + 1, j] +
                          matrix[i + 1, j + 1];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        col = i;
                        row = j;
                    }
                }
            }
            Console.WriteLine($"{matrix[col, row]} {matrix[col, row + 1]}");
            Console.WriteLine($"{matrix[col + 1, row]} {matrix[col + 1, row + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int[] ReadDigits()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}