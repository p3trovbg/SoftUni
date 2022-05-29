using System;
using System.Linq;
namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] arryOne = new int[num];
            int[] arryTwo = new int[num];

            for (int i = 0; i < num; i++)
            {
                int[] arry = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();              
                if (i % 2 == 0)
                {
                    arryOne[i] = arry[0];
                    arryTwo[i] = arry[1];
                }
                else
                {
                    arryTwo[i] = arry[0];
                    arryOne[i] = arry[1];
                }
            }
            Console.WriteLine(string.Join(' ', arryOne));
            Console.WriteLine(string.Join(' ', arryTwo));
        }
    }
}
