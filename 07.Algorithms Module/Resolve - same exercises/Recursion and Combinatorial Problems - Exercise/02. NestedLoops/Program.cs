using System;

namespace _02._NestedLoops
{
    internal class Program
    {
        private static int n;
        private static int[] combinations;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            combinations = new int[n];

            SimulateNestedLoops(0);
        }

        private static void SimulateNestedLoops(int idx)
        {
            if(idx >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = 0; i < combinations.Length; i++)
            {
                combinations[idx] = i + 1;
                SimulateNestedLoops(idx + 1);
            }
        }
    }
}
