using System;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int[] coordinates = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                    if (matrix[i, j] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[i, j] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            int ships = 0;
            for (int i = 0; i < coordinates.Length; i += 2)
            {
                int row = coordinates[i];
                int col = coordinates[i + 1];
                if (!Inside(matrix, row, col))
                {
                    continue;
                }
                //Explosion
                else if (matrix[row, col] == '#')
                {
                    for (int j = row - 1; j <= row + 1; j++)
                    {
                        for (int k = col - 1; k <= col + 1; k++)
                        {
                            if (Inside(matrix, j, k))
                            {
                                if (matrix[j, k] == '#' ||
                                    matrix[j, k] == '*' ||
                                    matrix[j, k] == 'X')
                                {
                                    matrix[j, k] = 'X';
                                    continue;
                                }

                                else if (matrix[j, k] == '>')
                                {
                                    secondPlayerShips--;
                                }
                                else if (matrix[j, k] == '<')
                                {
                                    firstPlayerShips--;
                                }
                                ships++;
                                matrix[j, k] = 'X';
                            }
                        }
                    }
                }
                else if (matrix[row, col] == '>')
                {
                    matrix[row, col] = 'X';
                    ships++;
                    secondPlayerShips--;
                }
                else if (matrix[row, col] == '<')
                {
                    matrix[row, col] = 'X';
                    ships++;
                    firstPlayerShips--;
                }

                if (firstPlayerShips <= 0 || secondPlayerShips <= 0)
                {
                    break;
                }
            }

            if (secondPlayerShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {ships} ships have been sunk in the battle.");

            }
            else if (firstPlayerShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {ships} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }

        private static bool Inside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                  col >= 0 && col < matrix.GetLength(1);
        }
    }
}
