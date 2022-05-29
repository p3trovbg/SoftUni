using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
  
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            
            foreach (var name in names.Where(x => x.Length <= length).ToArray())
            {
                Console.WriteLine(name);
            }
        }
    }
}
