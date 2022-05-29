using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var box = new HashSet<string>();

            for (int i = 0; i < counter; i++)
            {
                string name = Console.ReadLine();
                box.Add(name);
            }
            foreach (var name in box)
            {
                Console.WriteLine(name);
            }
        }
    }
}