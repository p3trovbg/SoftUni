using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> PrintAction = x =>
            {
                foreach (var knights in x)
                {
                    Console.WriteLine($"Sir {knights}");
                }
            };
            string[] names = Console.ReadLine().Split();
            PrintAction(names);
        }
    }
}
