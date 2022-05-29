using System;

namespace GenericBoxofInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(input);
            }
        }
    }
}
