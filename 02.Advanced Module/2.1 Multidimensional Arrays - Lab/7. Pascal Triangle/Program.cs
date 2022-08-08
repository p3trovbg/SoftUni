using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] array = new long[n][];

            for (int i = 0; i < n; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    row[j] = array[i - 1][j] +
                             array[i - 1][j - 1];
                }
                array[i] = row;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", array[i]));
            }
        }
    }
}