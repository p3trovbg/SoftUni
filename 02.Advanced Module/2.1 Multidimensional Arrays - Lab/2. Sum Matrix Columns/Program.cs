using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = ReadDigits();
            int[,] matrix = new int[parameters[0], parameters[1]];

            for (int i = 0; i < parameters[0]; i++)
            {
                int[] digits = ReadDigits();
                for (int j = 0; j < parameters[1]; j++)
                {
                    matrix[i, j] = digits[j];
                }
            }
            ;
            for (int i = 0; i < parameters[1]; i++)
            {
                int sum = 0;
                for (int j = 0; j < parameters[0]; j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }

            static int[] ReadDigits()
            {
                return Console.ReadLine()
                    .Split(new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
        }
    }
}