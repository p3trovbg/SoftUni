using System;

namespace _02.Super_Mario
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
                    if (line[j] == 'M')
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
                matrix[row, col] = 'B';
                healthArmy--;
                matrix[rowArmy, colArmy] = '-';
                //It can be "W" (up), "S" (down), "A" (left), "D" (right).
                switch (direction)
                {
                    case "W":
                        if (rowArmy - 1 >= 0)
                        {
                            matrix[rowArmy, colArmy] = '-';
                            rowArmy--;
                        }
                        break;
                    case "S":
                        if (rowArmy + 1 < matrix.GetLength(0))
                        {
                            matrix[rowArmy, colArmy] = '-';
                            rowArmy++;
                        }
                        break;
                    case "A":
                        if (colArmy - 1 >= 0)
                        {
                            matrix[rowArmy, colArmy] = '-';
                            colArmy--;
                        }
                        break;
                    case "D":
                        if (colArmy + 1 < matrix.GetLength(1))
                        {
                            matrix[rowArmy, colArmy] = '-';
                            colArmy++;
                        }
                        break;
                }
                if (matrix[rowArmy, colArmy] == 'B')
                {
                    healthArmy -= 2;
                }

                if (matrix[rowArmy, colArmy] == 'P')
                {
                    matrix[rowArmy, colArmy] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {healthArmy}");
                    break;
                }

                if (healthArmy <= 0)
                {
                    matrix[rowArmy, colArmy] = 'X';
                    Console.WriteLine($"Mario died at {rowArmy};{colArmy}.");
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
