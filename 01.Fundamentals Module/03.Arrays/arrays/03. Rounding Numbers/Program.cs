using System;
using System.Linq;
namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arry = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < arry.Length; i++)
            {
                Console.WriteLine($"{(decimal)arry[i]} => {(decimal)Math.Round(arry[i], MidpointRounding.AwayFromZero)}");
            }
           

        }
    }
}
