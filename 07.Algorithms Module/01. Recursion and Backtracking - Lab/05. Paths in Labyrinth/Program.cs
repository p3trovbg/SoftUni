using System;
using System.Collections.Generic;

namespace _05._Paths_in_Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            var matrix = new char[row, col];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var colElements = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            FindPath(matrix, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPath(char[,] matrix, int row, int col, List<string> directions, string direction)
        {
            if (IsOutOfMatrix(matrix, row, col)) return;

            if(matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);
            if(matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[row, col] = 'v';

            FindPath(matrix, row, col - 1, directions, "L"); //LEFT;
            FindPath(matrix, row, col + 1, directions, "R"); //RIGHT;
            FindPath(matrix, row - 1, col, directions, "U"); //UP;
            FindPath(matrix, row + 1, col, directions, "D"); //DOWN;

            matrix[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);

        }

        private static bool IsOutOfMatrix(char[,] matrix, int row, int col)
        {
            return row < 0 ||
                   col < 0 || 
                   row >= matrix.GetLength(0) || 
                   col >= matrix.GetLength(1);
        }
    }
}
