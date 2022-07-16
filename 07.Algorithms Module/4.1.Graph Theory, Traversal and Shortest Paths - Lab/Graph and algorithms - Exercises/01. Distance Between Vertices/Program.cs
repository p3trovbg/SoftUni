using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    internal class Program
    {
        private static Dictionary<int, HashSet<int>> graph;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pathCount = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, HashSet<int>>();
            FillGraph(n);
            FindAllPaths(pathCount);

        }

        private static void FindAllPaths(int pathCount)
        {
            var results = new Queue<string>();
            for (int i = 0; i < pathCount; i++)
            {
                var line = Console.ReadLine().Split("-");

                var initialEdge = int.Parse(line[0]);
                var endDestination = int.Parse(line[1]);

                int counter = SearchShortPath(initialEdge, endDestination);
                var result = $"{{{initialEdge}, {endDestination}}} -> {counter}";
                results.Enqueue(result);

            }

            PrintResult(results);
        }

        private static void PrintResult(Queue<string> results)
        {
            Console.WriteLine(String.Join(Environment.NewLine, results));
        }

        private static int SearchShortPath(int initialEdge, int endDestination)
        {
            var path = new int[graph.Max(x => x.Key) + 1];
            Array.Fill(path, -1);

            var visited = new HashSet<int>();

            var queue = new Queue<int>();
            queue.Enqueue(initialEdge);
            visited.Add(initialEdge);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == endDestination)
                {
                    int counter = 0;
                    while (endDestination != -1)
                    {
                        endDestination = path[endDestination];
                        counter++;
                    }

                    return counter - 1;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child) && child != node)
                    {
                        path[child] = node;
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }

            return -1;
        }

        private static void FillGraph(int n)
        {
            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine()
                    .Split(":");

                var parent = int.Parse(line[0]);

                if (string.IsNullOrEmpty(line[1]))
                {
                    graph.Add(parent, new HashSet<int>());
                }
                else
                {
                    var children = line[1]
                        .Split(" ")
                        .Select(int.Parse)
                        .ToHashSet();

                    graph.Add(parent, children);

                }
            }
        }
    }
}