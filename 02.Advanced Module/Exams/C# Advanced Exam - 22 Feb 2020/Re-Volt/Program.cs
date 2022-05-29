using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int rowPlayer = 0, colPlayer = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'f')
                    {
                        rowPlayer = i;
                        colPlayer = j;
                    }
                    matrix[i, j] = line[j];
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        if (Inside(matrix, rowPlayer - 1, colPlayer))
                        {
                            matrix[rowPlayer, colPlayer] = '-';
                            rowPlayer--;
                            if (matrix[rowPlayer, colPlayer] == 'B' && Inside(matrix, rowPlayer - 1, colPlayer))
                            {
                                matrix[rowPlayer, colPlayer] = '-';
                                matrix[rowPlayer - 1, colPlayer] = 'f';
                            }
                        }
                        break;
                    case "down":
                        
                        break;
                    case "left":
                                            
                        break;
                    case "right":
                       
                        break;
                }

                if (matrix[rowPlayer, colPlayer] == 'F')
                {
                    Console.WriteLine("Player won!");
                    PrintResult(matrix);
                    return;
                }
            }
            Console.WriteLine("Player lost!");
            PrintResult(matrix);
        }

        private static void PrintResult(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool Inside(char[,] matrix, int rowPlayer, int colPlayer)
        {
            return rowPlayer >= 0 && rowPlayer < matrix.GetLength(0) &&
                   colPlayer >= 0 && colPlayer < matrix.GetLength(1);

        }
    }
}
