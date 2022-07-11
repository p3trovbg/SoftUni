using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cinema
{
    internal class Program
    {
        private static bool[] used;
        private static List<string> nonStaticWatchers;
        private static string[] watchers;

        static void Main(string[] args)
        {
            nonStaticWatchers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            watchers = new string[nonStaticWatchers.Count];
            used = new bool[nonStaticWatchers.Count];

            string input;
            while ((input = Console.ReadLine()) != "generate")
            {
                var watcher = input.Split(" - ");
                var name = watcher[0];
                var position = int.Parse(watcher[1]) - 1;

                used[position] = true;
                watchers[position] = name;
                nonStaticWatchers.Remove(name);
            }

            GenVariatinos(0);
    
        }

        private static void GenVariatinos(int idx)
        {
            if(idx >= nonStaticWatchers.Count)
            {
                PrintResult();
                return;
            }

            GenVariatinos(idx + 1);

            for (int i = idx + 1; i < nonStaticWatchers.Count; i++)
            {
                Swap(i, idx);
                GenVariatinos(idx + 1);
                Swap(i, idx);
            }
        }
        private static void Swap(int firstIdx, int secondIdx)
        {
            var temp = nonStaticWatchers[firstIdx];
            nonStaticWatchers[firstIdx] = nonStaticWatchers[secondIdx];
            nonStaticWatchers[secondIdx] = temp;
        }
        private static void PrintResult()
        {
            var idx = 0;
            for (int i = 0; i < watchers.Length; i++)
            {
                if (!used[i])
                {
                    watchers[i] = nonStaticWatchers[idx++];
                }
            }

            Console.WriteLine(string.Join(" ", watchers));
        }
    }
}
