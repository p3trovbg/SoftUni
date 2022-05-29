using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            for (long i = 0; i < number; i++)
            {
                Console.WriteLine($"{result(number)}");
            }
        }

        static string result(long num)
        {
            string result= "";
            for (long i = 0; i < num - 1; i++)
            {
                Console.Write($"{num} ");
                result = $"{num}";
            }

            return result;
        }
       
    }
}
