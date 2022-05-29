using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            string name = names.First(x => x.Select(x => (int)x).Sum() >= limit);
            Console.WriteLine(name);
        }
    }
}
