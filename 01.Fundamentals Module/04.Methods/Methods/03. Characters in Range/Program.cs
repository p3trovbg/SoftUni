using System;
using System.Threading;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            Console.Write($"{Result(a, b)} ");
        }

        static string Result (char a, char b)
        {
            string result = "";
            if (a > b)
            {
                char originalB = b;
                b = a;
                a = originalB;
            }
            for (long i = a + 1; i < b; i++)
            {
                result += (char)i + " ";
            }

            return result;
        }
    }
}
