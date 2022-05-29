using System;

namespace _04._Prlonging_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNum = 1;
            long lastNum = long.Parse(Console.ReadLine());
            for (long i = firstNum; i <= lastNum; i++)
            {
                Result(firstNum, i);
            }
            for (long i = lastNum - 1; i >= firstNum; i--)
            {
                Result(firstNum, i);
            }
        }
        static void Result(long start, long end)
        {
            for (long i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

        }

    }
}
