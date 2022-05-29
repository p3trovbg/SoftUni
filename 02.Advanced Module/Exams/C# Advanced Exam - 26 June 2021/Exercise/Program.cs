using System;
using System.Linq;
using System.Text;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[i, n - j - 1] = '#';
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == '\0')
                    {
                        matrix[i, j] = ' ';
                    }
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}