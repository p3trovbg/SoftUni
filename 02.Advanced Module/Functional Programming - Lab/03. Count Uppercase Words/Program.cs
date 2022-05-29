using System;
using System.Linq;

namespace _03._Count_Uppercase
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))
                .ToArray();
            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}