using System;
using System.Collections.Generic;

namespace _03._Longest_Common_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstSequnce = Console.ReadLine();
            var secondSequnce = Console.ReadLine();

            var matrix = new int[firstSequnce.Length + 1, secondSequnce.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstSequnce[row - 1] == secondSequnce[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        var up = matrix[row - 1, col];
                        var left = matrix[row, col - 1];
                        matrix[row, col] = Math.Max(up, left);
                    }
                }
            }

            Console.WriteLine(matrix[firstSequnce.Length, secondSequnce.Length]);
            var _row = firstSequnce.Length - 1;
            var _col = secondSequnce.Length - 1;

            var result = new Stack<char>();
            while (_row >= 0 && _col >= 0)
            {
                if (firstSequnce[_row] == secondSequnce[_col])
                {
                    result.Push(firstSequnce[_row]);
                    _row--;
                    _col--;
                }
                else if (matrix[_row - 1, _col] > matrix[_row, _col - 1])
                {
                    _row -= 1;
                }
                else
                {
                    _col -= 1;
                }
            }

            Console.WriteLine(String.Join("", result));
        }
    }
}
