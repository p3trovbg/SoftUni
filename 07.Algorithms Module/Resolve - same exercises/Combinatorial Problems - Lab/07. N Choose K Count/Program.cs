using System;

namespace _07._N_Choose_K_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetCombinationsCount(n, k));
        }

        private static int GetCombinationsCount(int row, int col)
        {
            if (col == 0 || col == row || row <= 1)
            {
                return 1;
            }

            return GetCombinationsCount(row - 1, col) + GetCombinationsCount(row - 1, col - 1);
        }
    }
}
