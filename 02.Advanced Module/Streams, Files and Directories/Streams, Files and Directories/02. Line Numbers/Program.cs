using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"C:\Users\Petrov\Desktop\text.txt");
            int idx = 1;
            while (!sr.EndOfStream)
            {
                Console.WriteLine($"{idx}. {sr.ReadLine()}");
                idx++;
            }
        }
    }
}
