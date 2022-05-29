using System;
using System.Linq;

namespace TheBattleFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int healthArmy = int.Parse(Console.ReadLine());
            int sizeMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            int rowArmy = 0;
            int colArmy = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                if (i == 0)
                {
                    matrix = new char[sizeMatrix, line.Length];
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j] == 'A')
                    {
                        rowArmy = i;
                        colArmy = j;
                    }
                    matrix[i, j] = line[j];
                }
            }

            while (true)
            {
                string[] operation = Console.ReadLine().Split();
                string direction = operation[0];
                int row = int.Parse(operation[1]);
                int col = int.Parse(operation[2]);
                matrix[row, col] = 'O';
                healthArmy--;
                matrix[rowArmy, colArmy] = '-';
                switch (direction)
                {
                    case "up":
                        if (rowArmy - 1 >= 0)
                        {
                            matrix[rowArmy, colArmy] = '-';
                            rowArmy--;
                        }
                        break;
                    case "down":
                        if (rowArmy + 1 < matrix.GetLength(0))
                        {
                            matrix[rowArmy, colArmy] = '-';
                            rowArmy++;
                        }
                        break;
                    case "left":
                        if (colArmy - 1 >= 0)
                        {
                            matrix[rowArmy, colArmy] = '-';
                            colArmy--;
                        }
                        break;
                    case "right":
                        if (colArmy + 1 < matrix.GetLength(1))
                        {
                            matrix[rowArmy, colArmy] = '-';
                            colArmy++;
                        }
                        break;
                }
                if (matrix[rowArmy, colArmy] == 'O')
                {
                    healthArmy -= 2;
                }

                if (matrix[rowArmy, colArmy] == 'M')
                {
                    matrix[rowArmy, colArmy] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {healthArmy}");
                    break;
                }

                if (healthArmy <= 0)
                {
                    matrix[rowArmy, colArmy] = 'X';
                    Console.WriteLine($"The army was defeated at {rowArmy};{colArmy}.");
                    break;
                }
                matrix[rowArmy, colArmy] = 'A';
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}