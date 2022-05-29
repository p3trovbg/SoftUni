using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

           int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
           foreach (var item in array)
           {
                Console.WriteLine(item);
           }
cw        }
    }
}
