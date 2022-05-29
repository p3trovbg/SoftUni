using System;
using System.Linq;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] middle = new string[input.Length];
            for (long i = 0; i < input.Length; i++)
            {
                middle[i] += input[i];
            }

            Console.WriteLine(Middle(middle));
        }
        static string Middle(string[] middle)
        {
            string result = "";
            for (long i = 0; i < middle.Length / 2; i++)
            {
                if (middle.Length % 2 == 0)
                {
                    result = middle[i];
                    result += middle[i + 1];
                }
                else
                {
                    result = middle[i + 1];
                }
            }
            return result;
        }
    }
}
