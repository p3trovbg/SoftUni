using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> Print = x =>
            {
                foreach (var name in x)
                {
                    Console.WriteLine(name);
                }
            };
            Print(names);
        }
    }
}
