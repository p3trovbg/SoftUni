using System;
using System.Linq;

namespace _06._Connecting_Cables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var set = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine($"Maximum pairs connected: {GetConnectingCables(set)}");
        }

        private static int GetConnectingCables(int[] set)
        {
            int n = set.Length;
            var matrix = new int[n + 1, n + 1];
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    var rowValue = set[row - 1];
                    var colvalue = col;

                    if (rowValue == colvalue)
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        var left = matrix[row, col - 1];
                        var up = matrix[row - 1, col];

                        var max = Math.Max(left, up);
                        matrix[row, col] = max;
                    }
                }
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }
    }
}
