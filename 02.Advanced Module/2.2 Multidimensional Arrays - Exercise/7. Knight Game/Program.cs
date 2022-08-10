using System;
using System.Globalization;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] charRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = charRow[j];
                }
            }

            int count = 0;
            int maxKnightsInDanger = int.MinValue;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int counts = 0;
            while (true)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            //1 part 
                            if (IsInside(row + 1, col + 2, n) && IsKnight(matrix[row + 1, col + 2]))
                            {
                                count++;
                            }
                            if (IsInside(row - 1, col + 2, n) && IsKnight(matrix[row - 1, col + 2]))
                            {
                                count++;
                            }
                            if (IsInside(row + 1, col - 2, n) && IsKnight(matrix[row + 1, col - 2]))
                            {
                                count++;
                            }
                            if (IsInside(row - 1, col - 2, n) && IsKnight(matrix[row - 1, col - 2]))
                            {
                                count++;
                            }

                            // part 2 
                            if (IsInside(row - 2, col + 1, n) && IsKnight(matrix[row - 2, col + 1]))
                            {
                                count++;
                            }
                            if (IsInside(row - 2, col - 1, n) && IsKnight(matrix[row - 2, col - 1]))
                            {
                                count++;
                            }
                            if (IsInside(row + 2, col - 1, n) && IsKnight(matrix[row + 2, col - 1]))
                            {
                                count++;
                            }
                            if (IsInside(row + 2, col + 1, n) && IsKnight(matrix[row + 2, col + 1]))
                            {
                                count++;
                            }
                        }
                        if (count > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = count;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;
                        }
                        count = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[mostDangerousKnightRow, mostDangerousKnightCol] = 'O';
                    counts++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(counts);
                    return;
                }
            }
        }

        private static bool IsKnight(char v)
        {
            return v == 'K';
        }

        private static bool IsInside(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}