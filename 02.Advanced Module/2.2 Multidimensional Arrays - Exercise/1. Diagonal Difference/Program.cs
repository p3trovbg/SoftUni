using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int left = 0;
            int right = 0;
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
                left += matrix[i, i];
                right += matrix[i, n - i - 1];
            }
            
            Console.WriteLine(Math.Abs(left - right));
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

