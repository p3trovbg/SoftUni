using System;

namespace _01._Sign_of_longeger_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(Result(number));
        }

        static string Result(long number)
        {
            string result = "";
            if (number > 0)
            {
                result = $"The number {number} is positive";
            }
            else if (number < 0)
            {
                result = $"The number {number} is negative.";
            }
            else if (number == 0)

            {
                result = $"The number {number} is zero.";
            }

            return result;
        }
    }
}
