using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
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


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] operations = input.Split();

                int row = int.Parse(operations[1]);
                int cow = int.Parse(operations[2]);
                int value = int.Parse(operations[3]);

                if (row < 0 || row >= n || cow < 0 || cow >= n)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;

                }
                switch (operations[0])
                {
                    case "Add":
                        matrix[cow, row] += value;
                        break;
                    case "Subtract":
                        matrix[cow, row] -= value;
                        break;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
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
