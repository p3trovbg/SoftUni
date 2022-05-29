using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = 10;
            int lastNum = int.Parse(Console.ReadLine());
            for (int i = firstNum; i <= lastNum; i++)
            {
                Result(firstNum, i);
            }
            for (int i = lastNum - 1; i >= firstNum; i--)
            {
                Result(firstNum, i);
            }
        }      
        static void Result(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
          
        }
    }
}
