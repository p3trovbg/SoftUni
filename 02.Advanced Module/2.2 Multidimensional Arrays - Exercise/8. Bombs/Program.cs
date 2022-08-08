using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] digits = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = digits[j];
                }
            }
            AfterBomb(matrix);
            Result(matrix);
        }
        private static void AfterBomb(int[,] matrix)
        {
            string[] coordinates = Console.ReadLine()
                .Split(" ")
                .ToArray();
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] idx = coordinates[i]
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();
                int col = idx[0];
                int row = idx[1];
                int bomb = matrix[col, row];

                for (int j = col - 1; j <= col + 1; j++)
                {
                    for (int k = row - 1; k <= row + 1; k++)
                    {
                        if (j >= 0 && j < matrix.GetLength(0) && k < matrix.GetLength(0) && k >= 0 && k < matrix.GetLength(1))
                        {
                            if (matrix[j, k] <= 0 || bomb < 0)
                            {
                                continue;
                            }
                            matrix[j, k] -= bomb;
                        }

                    }
                }
            }
        }

        private static void Result(int[,] matrix)
        {
            int sum = 0;
            int countAlive = 0;
            foreach (var digit in matrix)
            {
                if (digit > 0)
                {
                    sum += digit;
                    countAlive++;
                }
            }

            Console.WriteLine($"Alive cells: {countAlive}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
