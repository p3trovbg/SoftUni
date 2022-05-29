using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long iterations = long.Parse(Console.ReadLine());
            Console.WriteLine(Result(input, iterations));
        }

        static string Result(string input, long rotations)
        {
            string result = "";
            for (long i = 0; i < rotations - 1; i++)
            {
                result = input;
                Console.Write(result);
            }

            return result;
        }
    }
}
