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
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line.Split()
                                       .Select(int.Parse)
                                       .ToList();

                    graph[node] = children;

                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                components = new List<int>();
                if (visited[node])
                {
                    continue;
                }

                DFS(node);
                Console.WriteLine($"Connected component: {String.Join(" ", components)}");
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
