using System;
using System.Linq;

namespace AdvancedExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = ReadDigits();

            int[,] matrix = new int[parameters[0], parameters[1]];
            int sum = 0;
            for (int i = 0; i < parameters[0]; i++)
            {
                int[] digits = ReadDigits();
                for (int j = 0; j < parameters[1]; j++)
                {
                    matrix[i, j] = digits[j];
                    sum += digits[j];
                }
            }

            Console.WriteLine(parameters[0]);
            Console.WriteLine(parameters[1]);
            Console.WriteLine(sum);
        }

        private static int[] ReadDigits()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}