using System;
using System.Linq;
namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int collection = 0;
            for (int i = 0; i < arry.Length; i++)
            {
                if (arry[i] % 2 == 0)
                {
                    collection += arry[i];
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine(collection);
        }
    }
}
