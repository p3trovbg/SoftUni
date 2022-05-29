using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split()
                .Where(x => x.Length % 2 == 0)
                .ToList();
            words.ForEach(x => Console.WriteLine(x));
        }



    }
}
