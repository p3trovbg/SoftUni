using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new String[parameters[0], parameters[1]];

            for (int i = 0; i < parameters[0]; i++)
            {
                string[] latters = ReadDigits();
                for (int j = 0; j < parameters[1]; j++)
                {
                    matrix[i, j] = latters[j];
                }
            }

            int count = 0;
            for (int i = 0; i < parameters[0] - 1; i++)
            {
                for (int j = 0; j < parameters[1] - 1; j++)
                {
                    string symbol = matrix[i, j];
                    if (symbol == matrix[i, j + 1] &&
                        symbol == matrix[i + 1, j] &&
                        symbol == matrix[i + 1, j + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static string[] ReadDigits()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}

