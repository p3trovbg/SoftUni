using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int n = int.Parse(Console.ReadLine());
            int[] arry = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                arry[i] = int.Parse(Console.ReadLine());
                sum += arry[i];
            }
            Console.WriteLine(string.Join(' ', arry));
            Console.WriteLine(sum);
        }
    }
}
