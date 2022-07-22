using System;

namespace _07._N_Choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetCombinations(n, k));
        }

        private static int GetCombinations(int row, int col)
        {
            if(col == 0 || col == row || row <= 1)
            {
                return 1;
            }

            return GetCombinations(row - 1, col) + GetCombinations(row - 1, col - 1);
        }
    }
}
