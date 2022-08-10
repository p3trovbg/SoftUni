using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] operations = Console.ReadLine()
                .Split();

            char[,] matrix = new char[n, n];
            int coal = 0;
            int[] startPositions = new int[2];
            for (int i = 0; i < n; i++)
            {
                char[] rows = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    if (rows[j] == 'c')
                    {
                        coal++;
                    }
                    if (rows[j] == 's')
                    {
                        startPositions[0] = i;
                        startPositions[1] = j;
                    }
                    matrix[i, j] = rows[j];
                }
            }
            int row = startPositions[0];
            int col = startPositions[1];
            for (int i = 0; i < operations.Length; i++)
            {
                string command = operations[i];
                switch (command)
                {
                    case "up":
                        if (row - 1 >= 0)
                        {
                            row -= 1;
                        }
                        break;
                    case "down":
                        if (row + 1 < matrix.GetLength(0))
                        {
                            row += 1;
                        }
                        break;
                    case "right":
                        if (col + 1 < matrix.GetLength(1))
                        {
                            col += 1;
                        }
                        break;
                    case "left":
                        if (col - 1 >= 0)
                        {
                            col -= 1;
                        }
                        break;
                }
                if (matrix[row, col] == 'c')
                {
                    if (coal == 0 || coal - 1 == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({row}, {col})");
                        return;
                    }
                    else
                    {
                        coal -= 1;
                        matrix[row, col] = '*';
                    }
                }
                else if (matrix[row, col] == 'e')
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
            }

            Console.WriteLine($"{coal} coals left. ({row}, {col})");
        }
    }
}
