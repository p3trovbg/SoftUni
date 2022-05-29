using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var myList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                myList.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(myList, indexs[0], indexs[1]);
        }

        private static void Swap<T>(List<T> list, int firstIdx, int secIdx)
        {
            T firstElement = list[firstIdx];
            list[firstIdx] = list[secIdx];
            list[secIdx] = firstElement;
            foreach (var elements in list)
            {
                Console.WriteLine($"{typeof(T)}: {elements}");
            }
        }
    }
}
