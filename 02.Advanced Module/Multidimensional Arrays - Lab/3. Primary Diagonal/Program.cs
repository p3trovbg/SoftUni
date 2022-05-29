using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int[] digits = ReadDigits();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = digits[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
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