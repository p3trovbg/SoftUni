using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] digits = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                matrix[i] = digits;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    MatrixSum(matrix, i);
                    MatrixSum(matrix, i + 1);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] operations = input.Split();
                string command = operations[0];

                int col = int.Parse(operations[1]);
                int row = int.Parse(operations[2]);
                int value = int.Parse(operations[3]);

                bool validCol = col < 0 || col >= n;
                if (!validCol)
                {
                    bool validRow = row < 0 || row >= matrix[col].Length;
                    if (!validRow)
                    {
                        if (command == "Add")
                        {
                            matrix[col][row] += value;
                        }
                        else
                        {
                            matrix[col][row] -= value;
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }

        }

        static void MatrixSum(double[][] matrix, int idx)
        {
            for (int j = 0; j < matrix[idx].Length; j++)
            {
                matrix[idx][j] /= 2;
            }
        }
    }
}
