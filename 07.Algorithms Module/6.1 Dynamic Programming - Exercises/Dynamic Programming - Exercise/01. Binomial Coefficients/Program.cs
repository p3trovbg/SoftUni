using System;
using System.Collections.Generic;

namespace _01._Binomial_Coefficients
{
    internal class Program
    {
        private static Dictionary<string, long> coeffiecients;
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            coeffiecients = new Dictionary<string, long>();

            var result = GetBinomialCoefficient(row, col);
            Console.WriteLine(result);
            ;
        }

        private static long GetBinomialCoefficient(int row, int col)
        {
            var coefficient = $"{row} {col}";
            if(coeffiecients.ContainsKey(coefficient))
            {
                return coeffiecients[coefficient];
            }
            if (col == 0 || col == row || row <= 1)
            {
                return 1;
            }

            var result =  GetBinomialCoefficient(row - 1, col) + GetBinomialCoefficient(row - 1, col - 1);

            coeffiecients[coefficient] = result;

            return result;
        }
    }
}
