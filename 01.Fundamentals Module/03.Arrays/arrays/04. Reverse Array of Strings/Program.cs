using System;
using System.Linq;
namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < items.Length / 2; i++)
            {
                var oddItems = items[i];
                items[i] = items[items.Length - 1 - i];
                items[items.Length - 1 - i] = oddItems;
            }
            Console.WriteLine(string.Join(" ", items));
        }
    }
}
