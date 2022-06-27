using System;

namespace _03._Generating_0_1_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var arr = new int[input];
            Generator(arr, 0);
        }

        private static void Generator(int[] arr, int idx)
        {
            if(idx >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;
                Generator(arr, idx + 1);
            }
        }
    }
}
