using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Connected_Components
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static List<int> components;
        private static Action<List<int>> printResult;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];

            printResult = delegate (List<int> nodes)
            {
                Console.WriteLine($"Connected component: {String.Join(" ", nodes)}");
            };

            FillGraph(n);
            FindAllComponents();
        }

        private static void FillGraph(int n)
        {
            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                    continue;
                }

                var children = line.Split()
                                   .Select(int.Parse)
                                   .ToList();
                graph[node] = children;
            }
        }

        private static void FindAllComponents()
        {
            for (int node = 0; node < graph.Length; node++)
            {
                components = new List<int>();
                if (visited[node])
                {
                    continue;
                }

                DFS(node);

                printResult(components);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            components.Add(node);
        }
    }
}
