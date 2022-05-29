using System;
using System.Linq;

namespace _3._Maximal_Sum
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
            for (int i = 0; i < parameters[0] - 2; i++)
            {
                for (int j = 0; j < parameters[1] - 2; j++)
                {

                    sum =
                         //First row
                          matrix[i, j] + 
                          matrix[i, j + 1] +
                          matrix[i, j + 2] +
                          //Second row
                          matrix[i + 1, j] +
                          matrix[i + 1, j + 1] +
                          matrix[i + 1, j + 2] +
                          //Third row
                          matrix[i + 2, j] +
                          matrix[i + 2, j + 1] +
                          matrix[i + 2, j + 2];

                    //Add if sum > max sum.
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        col = i;
                        row = j;
                    }

                }
            }

            //PRINT
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[col, row]} {matrix[col, row + 1]} {matrix[col, row + 2]}");
            Console.WriteLine($"{matrix[col + 1, row]} {matrix[col + 1, row + 1]} {matrix[col + 1, row + 2]}");
            Console.WriteLine($"{matrix[col + 2, row]} {matrix[col + 2, row + 1]} {matrix[col + 2, row + 2]}");
           
        }

        private static int[] ReadDigits()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
