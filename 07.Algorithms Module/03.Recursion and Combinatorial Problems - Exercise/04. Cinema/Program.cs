using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Cinema
{
    class Program
    {
        private static bool[] locked;
        private static List<string> nonStaticWatcher;
        private static string[] watchers;
        static void Main(string[] args)
        {
            nonStaticWatcher = Console.ReadLine().Split(", ").ToList();
            locked = new bool[nonStaticWatcher.Count];
            watchers = new string[nonStaticWatcher.Count];

            var input = Console.ReadLine();
            while (input != "generate")
            {
                var temp = input.Split(" - ");
                var watcherName = temp[0];
                var watcherPosition = int.Parse(temp[1]) - 1;

                locked[watcherPosition] = true;
                watchers[watcherPosition] = watcherName;

                nonStaticWatcher.Remove(watcherName);
                input = Console.ReadLine();
            }


            GenPermutations(0);
        }

        private static void GenPermutations(int idx)
        {
            if(idx >= nonStaticWatcher.Count)
            {
                PrintResult();
                return;
            }

            GenPermutations(idx + 1);

            for (int i = idx + 1; i < nonStaticWatcher.Count; i++)
            {
                Swap(idx, i);
                GenPermutations(idx + 1);
                Swap(idx, i);
            }
        }

        private static void Swap(int firstIdx, int secondIdx)
        {
            var temp = nonStaticWatcher[firstIdx];
            nonStaticWatcher[firstIdx] = nonStaticWatcher[secondIdx];
            nonStaticWatcher[secondIdx] = temp;
        }

        private static void PrintResult()
        {
            var idx = 0;
            for (int i = 0; i < watchers.Length; i++)
            {
                if (!locked[i])
                {
                    watchers[i] = nonStaticWatcher[idx++];
                }
            }

            Console.WriteLine(string.Join(" ", watchers));
        }
    }
}
