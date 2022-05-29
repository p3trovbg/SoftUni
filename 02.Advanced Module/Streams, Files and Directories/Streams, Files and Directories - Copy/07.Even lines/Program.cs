using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;

namespace _07.Even_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using var sr =
                new StreamReader(@"text.txt");
            int idx = 0;
            char[] symbols = new char[] {'-', ',', '.', '!', '?' };
            using StreamWriter streamWriter = new StreamWriter(@"output.txt");
            while (!sr.EndOfStream)
            {
                if (idx % 2 == 0)
                {
                    string line = sr.ReadLine();
                    foreach (var symbol in symbols)
                    {
                        line = line.Replace(symbol, '@');
                    }
                    streamWriter.WriteLine(string.Join(" ", line.Split().Reverse()));
                }
                else
                {
                    sr.ReadLine();
                }

                idx++;
            }
        }
    }
}
