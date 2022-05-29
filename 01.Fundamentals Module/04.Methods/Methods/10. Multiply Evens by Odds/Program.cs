using System;
using System.Threading.Channels;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = Math.Abs(long.Parse(Console.ReadLine()));
            Console.WriteLine(Result(number));
        }

        static long Result(long number)
        {
            long odd = 0;
            long even = 0;
            while (number > 0)
            {
                long curretNumber = number % 10;
                if (curretNumber % 2 == 0)
                {
                    even += curretNumber;
                }
                else
                {
                    odd += curretNumber;
                }

                number /= 10;
            }

            return even * odd;
        }
    }
}
