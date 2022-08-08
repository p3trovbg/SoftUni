using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;

namespace _10._VampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[coordinates[0], coordinates[1]];
            int rowPlayer = 0;
            int colPlayer = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                    if (matrix[i, j] == 'P')
                    {
                        rowPlayer = i;
                        colPlayer = j;
                    }
                }
            }

            string commands = Console.ReadLine();
            for (int i = 0; i < commands.Length; i++)
            {
                char operation = commands[i];
                bool flag = false;
                switch (operation)
                {
                    case 'U':
                        if (Outside(rowPlayer - 1, colPlayer, matrix))
                        {
                            Replace(rowPlayer, colPlayer, matrix);
                            rowPlayer -= 1;
                            Spread(matrix);
                            flag = true;
                        }
                        break;
                    case 'D':
                        if (Outside(rowPlayer + 1, colPlayer, matrix))
                        {
                            Replace(rowPlayer, colPlayer, matrix);
                            rowPlayer += 1;
                            Spread(matrix);
                            flag = true;
                        }
                        break;
                    case 'L':
                        if (Outside(rowPlayer, colPlayer - 1, matrix))
                        {
                            Replace(rowPlayer, colPlayer, matrix);
                            colPlayer -= 1;
                            Spread(matrix);
                            flag = true;
                        }
                        break;
                    case 'R':
                        if (Outside(rowPlayer, colPlayer + 1, matrix))
                        {
                            Replace(rowPlayer, colPlayer, matrix);
                            colPlayer += 1;
                            Spread(matrix);
                            flag = true;
                        }
                        break;
                }

                if (!flag)
                {
                    Spread(matrix);
                    Result(matrix, rowPlayer, colPlayer, true);
                    return;
                }
                if (matrix[rowPlayer, colPlayer] == 'B')
                {
                    Result(matrix, rowPlayer, colPlayer, false);
                    return;
                }
            }
        }

        private static void Replace(int rowPlayer, int colPlayer, char[,] matrix)
        {
            matrix[rowPlayer, colPlayer] = '.';
            return;
        }

        private static void Spread(char[,] matrix)
        {
            var coordinatesBunny = new Queue<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        coordinatesBunny.Enqueue(i);
                        coordinatesBunny.Enqueue(j);
                    }
                }
            }
            while (coordinatesBunny.Count > 0)
            {
                int row = coordinatesBunny.Dequeue();
                int col = coordinatesBunny.Dequeue();
                //Right
                if (Outside(row, col + 1, matrix))
                {
                    matrix[row, col + 1] = 'B';
                }
                //Left
                if (Outside(row, col - 1, matrix))
                {
                    matrix[row, col - 1] = 'B';
                }
                //Down
                if (Outside(row + 1, col, matrix))
                {
                    matrix[row + 1, col] = 'B';
                }
                //Up
                if (Outside(row - 1, col, matrix))
                {
                    matrix[row - 1, col] = 'B';
                }
            }
        }
        private static void Result(char[,] matrix, int rowPlayer, int colPlayer, bool v)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

            if (v)
            {
                Console.WriteLine($"won: {rowPlayer} {colPlayer}");
            }
            else
            {
                Console.WriteLine($"dead: {rowPlayer} {colPlayer}");
            }
        }
        private static bool Outside(int row, int col, char[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
