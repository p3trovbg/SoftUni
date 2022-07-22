using System;

namespace _07._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonnaci(input));
        }

        private static int GetFibonnaci(int num)
        {
            if (num <= 1)
            {
                return 1;
            }

            return GetFibonnaci(num - 1) + GetFibonnaci(num - 2);
        }
    }
}
