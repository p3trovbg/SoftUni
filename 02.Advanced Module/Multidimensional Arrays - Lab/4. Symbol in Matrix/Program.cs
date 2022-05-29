using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            char[,] matrix = new char[counter, counter];

            for (int i = 0; i < counter; i++)
            {
                string text = Console.ReadLine();
                for (int j = 0; j < counter; j++)
                {
                    matrix[i, j] = text[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}