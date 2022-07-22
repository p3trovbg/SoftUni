using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Connected_Areas_in_Matrix
{
    public class Area
    {
        public Area(int row, int col, int size)
        {
            Row = row;
            Col = col;
            Size = size;
        }
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }

    class Program
    {
        private static int row;
        private static int col;
        private static char[,] matrix;
        private static int size;
        static void Main(string[] args)
        {
            row = int.Parse(Console.ReadLine());
            col = int.Parse(Console.ReadLine());
            matrix = new char[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var colElements = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            var allAreas = new List<Area>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    size = 0;
                    FindAreas(row, col);

                    if(size > 0)
                    {
                        allAreas.Add(new Area(row, col, size));
                    }
                }
            }

            var result = allAreas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col);
            Console.WriteLine($"Total areas found: {result.Count()}");
            var counter = 1;
            foreach (var area in result)
            {
                Console.WriteLine($"Area #{counter++} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void FindAreas(int row, int col)
        {
            if (IsOutside(row, col) || IsBusy(row, col) || IsWall(row, col))
            {
                return;
            }

            matrix[row, col] = 'v';
            size++;
            FindAreas(row, col + 1); //Right
            FindAreas(row + 1, col); // Down
            FindAreas(row, col - 1); //Left
            FindAreas(row - 1, col); //Up
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsBusy(int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }
    }
}
