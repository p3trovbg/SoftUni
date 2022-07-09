using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreas
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
    internal class Program
    {
        private static char[,] matrix;
        private static int size;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            var areas = new List<Area>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    GetAreaSize(row, col);

                    if (size > 0)
                    {
                        areas.Add(new Area(row, col, size));
                        size = 0;
                    }
                }
            }

            int counter = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList()
                .ForEach(a =>
                {
                    Console.WriteLine($"Area #{counter++} at ({a.Row}, {a.Col}), size: {a.Size}");
                });
        }

        private static void GetAreaSize(int row, int col)
        {
            if (IsOutside(row, col) ||
                IsBusy(row, col) ||
                IsWall(row, col))
            {
                return;
            }

            matrix[row, col] = 'v';
            size++;

            GetAreaSize(row, col + 1); //RIGHT
            GetAreaSize(row, col - 1); //LEFT
            GetAreaSize(row - 1, col); //UP
            GetAreaSize(row + 1, col); //DOWN

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
            return row < 0 ||
                   row >= matrix.GetLength(0) ||
                   col < 0 ||
                   col >= matrix.GetLength(1);
        }
    }
}
