using System;
using System.Linq;

namespace _4._Matrix_Shuffling
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
                string[] digits = ReadDigits();
                for (int j = 0; j < parameters[1]; j++)
                {
                    matrix[i, j] = digits[j];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] operations = input.Split();
                if (operations.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string command = operations[0];
                //"swap row1 col1 row2c col2"
                int firstCol = int.Parse(operations[1]);
                int firstRow = int.Parse(operations[2]);
                int secondCol = int.Parse(operations[3]);
                int secondRow = int.Parse(operations[4]);

                if (firstRow < 0 || firstRow >= parameters[1] ||
                    secondRow < 0 || secondRow >= parameters[1] ||
                    firstCol < 0 || firstCol >= parameters[0] ||
                    secondCol < 0 || secondCol >= parameters[0])
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string first = matrix[firstCol, firstRow];
                    string second = matrix[secondCol, secondRow];
                    matrix[firstCol, firstRow] = second;
                    matrix[secondCol, secondRow] = first;

                    for (int i = 0; i < parameters[0]; i++)
                    {
                        for (int j = 0; j < parameters[1]; j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
        static string[] ReadDigits()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
