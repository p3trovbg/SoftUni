using System;

namespace _03._Connected_Areas_in_Matrix
{
    class Program
    {
        private static int row;
        private static int col;
        private static char[,] matrix;
        private static int totalAreas;
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

            FindAreas(0);
            
        }

        private static void FindAreas(int row)
        {
            if(row >= matrix.GetLength(0))
            {
                return;
            }

            
        }
    }
}
