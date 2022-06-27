using System;

namespace _04._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            Console.WriteLine(SumFactorial(input));
        }

        private static int SumFactorial(int result)
        {
            if(result == 0)
            {
                return 1;
            }

            return result * SumFactorial(result - 1);
        }
    }
}
