using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[matrixSize[0], matrixSize[1]];

            string snake = Console.ReadLine();
            var queueSnake = new Queue<char>(snake.ToArray());

            for (int i = 0; i < matrixSize[0]; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrixSize[1]; j++)
                    {
                       matrix[i, j] = CurrentSymbol(queueSnake);
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = CurrentSymbol(queueSnake);
                    }
                }
            }

            Result(matrix);
        }

        private static char CurrentSymbol(Queue<char> queueSnake)
        {
            char symbol = queueSnake.Dequeue();
            queueSnake.Enqueue(symbol);
            return symbol;
        }

        private static void Result(char[,] matrix)
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
    }
}