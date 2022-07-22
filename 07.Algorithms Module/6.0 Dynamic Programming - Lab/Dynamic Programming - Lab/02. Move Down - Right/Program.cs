using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MoveDownRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            var newMatrix = new int[rows, cols];
            var path = new Stack<string>();

            newMatrix[0, 0] = matrix[0, 0];

            for (int i = 1; i < cols; i++)
            {
                newMatrix[0, i] = newMatrix[0, i - 1] + matrix[0, i]; 
            }

            for (int i = 1; i < rows; i++)
            {
                newMatrix[i, 0] = newMatrix[i - 1, 0] + matrix[i, 0];
            }

            for (int _row = 1; _row < rows; _row++)
            {
                for (int _col = 1; _col < cols; _col++)
                {
                    var upString = $"{_row - 1}, {_col}"; // For test
                    var leftString = $"{_row }, {_col - 1}"; // For test

                    var up = newMatrix[_row - 1, _col];
                    var left = newMatrix[_row, _col - 1];

                    var max = Math.Max(left, up);
                    newMatrix[_row, _col] = max + matrix[_row, _col];
                }
            }

            int row = rows - 1;
            int col = cols - 1;

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");
                var up = newMatrix[row - 1, col];
                var left = newMatrix[row, col - 1];
                 
                if(left < up)
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            while (row > 0)
            {
                path.Push($"[{row--}, {col}]");

            }

            while (col > 0)
            {
                path.Push($"[{row}, {col--}]");
            }

            path.Push($"[{row}, {col--}]");

            Console.WriteLine(String.Join(" ", path));
        }
    }
}
