using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Sign(num);
        }

        static void Sign(int number)
        {
            string sign = null;
            if (number > 0)
            {
                sign = "positive";
            }
            else if (number < 0)
            {
                sign = "negative";
            }
            else
            {
                sign = "zero";
            }

            Console.WriteLine($"The number {number} is {sign}.");
        }
    }
}
