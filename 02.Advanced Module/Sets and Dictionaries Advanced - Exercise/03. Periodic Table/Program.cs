using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();
                for (int j = 0; j < elements.Length; j++)
                {
                    box.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", box));
        }
    }
}
