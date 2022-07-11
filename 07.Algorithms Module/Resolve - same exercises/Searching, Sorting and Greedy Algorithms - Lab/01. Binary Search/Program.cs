using System;
using System.Linq;

namespace BinarySearchAlgorithm
{
    internal class Program
    {
        private static int[] array;
        private static int searchDigit;
        private static int idx = -1;

        static void Main(string[] args)
        {
            array = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(x => int.Parse(x))
                 .ToArray();

             searchDigit = int.Parse(Console.ReadLine());

            BinarySearch(0, array.Length - 1);
            Console.WriteLine(idx);
        }

        private static void BinarySearch(int leftPointer, int rightPointer)
        {
            if (leftPointer > rightPointer || rightPointer < leftPointer)
            {
                return;
            }

            var mid = (leftPointer + rightPointer) / 2;

            if (array[mid] == searchDigit)
            {
                 idx = mid;
                return;
            }

            if (array[mid] < searchDigit)
            {
                leftPointer = mid + 1;
                BinarySearch(leftPointer, rightPointer);
            }
            else
            {
                rightPointer = mid - 1;
                BinarySearch(leftPointer, rightPointer);
            }
        }
    }
}
