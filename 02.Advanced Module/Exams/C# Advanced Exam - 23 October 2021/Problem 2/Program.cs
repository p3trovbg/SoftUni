using System;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] matrix = new char[8, 8];
            int blackRow = 0;
            int blackCol = 0;
            int whiteRow = 0;
            int whiteCol = 0;
            for (int i = 0; i < 8; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = line[j];
                    if (line[j] == 'b')
                    {
                        blackRow = i;
                        blackCol = j;
                    }
                    else if (line[j] == 'w')
                    {
                        whiteRow = i;
                        whiteCol = j;
                    }
                }
            }
            int count = 0;
            while (true)
            {
                bool flag = false;
                if (count % 2 == 0)
                {
                   if (whiteRow - 1 >= 0 && whiteCol - 1 >= 0 && matrix[whiteRow - 1, whiteCol - 1] == 'b')
                    {
                        matrix[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        whiteCol--;
                        flag = true;
                    }
                   else if (whiteRow - 1 >= 0 && whiteCol + 1 < 8 && matrix[whiteRow - 1, whiteCol + 1] == 'b')
                    {
                        matrix[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        whiteCol++;
                        flag = true;
                    }
                    if (flag)
                    {
                        matrix[whiteRow, whiteCol] = 'w';        
                        Console.WriteLine($"Game over! White capture on {(char)(whiteCol + 97)}{8 - whiteRow}.");
                        return;
                    }
                    else
                    {
                        matrix[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        matrix[whiteRow, whiteCol] = 'w';
                    }
                }
                else
                {                   
                    if (blackRow + 1 < 8 && blackCol - 1 >= 0 && matrix[blackRow + 1, blackCol - 1] == 'w')
                    {
                        matrix[whiteRow, whiteCol] = '-';
                        blackRow++;
                        blackCol--;
                        flag = true;
                    }
                    else if (blackRow + 1 < 8 && blackCol + 1 < 8 && matrix[blackRow + 1, blackCol + 1] == 'w')
                    {
                        matrix[whiteRow, whiteCol] = '-';
                        blackRow++;
                        blackCol++;
                        flag = true;
                    }
                    if (flag)
                    {
                        Console.WriteLine($"Game over! Black capture on {(char)(blackCol + 97)}{8 - blackRow}.");
                        return;
                    }
                    else
                    {
                        matrix[blackRow, blackCol] = '-';
                        blackRow++;
                        matrix[blackRow, blackCol] = 'b';
                    }
                }

                if (whiteRow == 0)
                { 
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteCol + 97)}8.");
                    break;
                }
                else if (blackRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackCol + 97)}1.");
                    break;
                }
                
                count++;              
            }
        }
    }
}
