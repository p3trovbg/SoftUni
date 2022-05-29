using System;
using System.Linq;
namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int magicNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < arry.Length; i++)
            {
                for (int j = i + 1; j < arry.Length; j++)
                {
                    if (arry[i] + arry[j] == magicNumber)
                    {
                        Console.WriteLine($"{arry[i]} {arry[j]}");
                        break;
                    }
                }
            }
        }
    }
}
