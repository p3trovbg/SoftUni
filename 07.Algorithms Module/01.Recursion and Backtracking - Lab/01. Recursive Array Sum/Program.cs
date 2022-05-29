using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(GetSum(inputArr, 0));
        }

        private static int GetSum(int[] array, int idx)
        {
            if(idx >= array.Length)
            {
                return 0;
            }

            return array[idx] += GetSum(array, idx + 1);
        }
    }
}
