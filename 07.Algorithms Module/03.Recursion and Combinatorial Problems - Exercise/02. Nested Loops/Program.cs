using System;

namespace _02._Nested_Loops
{
    class Program
    {
        private static int[] arr;
        static void Main(string[] args)
        {
            int slots = int.Parse(Console.ReadLine());
            arr = new int[slots];

            NestedLoops(0);
        }

        private static void NestedLoops(int idx)
        {
            if(idx >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[idx] = i;
                NestedLoops(idx + 1);
            }
        }
    }
}
