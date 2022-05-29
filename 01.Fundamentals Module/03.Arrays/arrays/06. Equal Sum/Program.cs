using System;
using System.Linq;
namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            bool flag = false;
         
            for (int i = 0; i < arry.Length; i++)
            {
                if (arry.Length == 1)
                {
                    Console.WriteLine(i);
                    break;
                }
                int rigtSum = 0;
                int leftSum = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += arry[j];
                }
                for (int k = i + 1; k < arry.Length; k++)
                {
                    rigtSum += arry[k];
                }
                if (rigtSum == leftSum)
                {
                    Console.WriteLine(i);
                    flag = true;
                    break;
                }
            } 
            if (!flag && arry.Length != 1)
            {
                Console.WriteLine("no");
            }
        }
    }
}
