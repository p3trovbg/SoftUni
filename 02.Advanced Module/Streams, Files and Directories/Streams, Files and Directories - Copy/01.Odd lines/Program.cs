using System;
using System.IO;

namespace _01.Odd_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"C:\Users\Petrov\Desktop\text.txt");
            int idx = 0;
            while (!sr.EndOfStream)
            {
                if (idx % 2 == 1)
                {
                    Console.WriteLine(sr.ReadLine());
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
