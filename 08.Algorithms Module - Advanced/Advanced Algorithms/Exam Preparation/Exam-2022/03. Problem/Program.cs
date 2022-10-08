using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    public class Program
    {

        static void Main(string[] args)
        {
            var firstSequnce = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondSequnce = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new int[firstSequnce.Length + 1][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[secondSequnce.Length + 1];
            }


            for (int row = 1; row < matrix.Length; row++)
            {
                for (int col = 1; col < matrix[row].Length; col++)
                {
                    if (firstSequnce[row - 1] == secondSequnce[col - 1])
                    {
                        matrix[row][col] = matrix[row - 1][col - 1] + 1;
                    }
                    else
                    {
                        var up = matrix[row - 1][ col];
                        var left = matrix[row][col- 1];
                        matrix[row][col] = Math.Max(up, left);
                    }
                }
            }


            var _row = firstSequnce.Length;
            var _col = secondSequnce.Length;
            var result = new Stack<int>();

            while (_row > 0 && _col > 0)
            {
                if (firstSequnce[_row - 1] == secondSequnce[_col - 1])
                {
                    result.Push(firstSequnce[_row - 1]);
                    _row--;
                    _col--;
                }
                else if (matrix[_row - 1][_col] > matrix[_row][_col - 1])
                {
                    _row -= 1;
                }
                else
                {
                    _col -= 1;
                }
            }

            Console.WriteLine(String.Join(" ", result));
            Console.WriteLine(result.Count());

        }
    }
}
