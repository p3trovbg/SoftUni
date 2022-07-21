using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shortest_Path
{
    internal class Program
    {
        private static HashSet<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = new HashSet<int>[n + 1];
            visited = new bool[n + 1];
           
            FillGraph(edges);

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
          
            FindShortPath(start, end);
        }

        private static void FindShortPath(int start, int end)
        {
            var path = new int[graph.Length];
            Array.Fill(path, -1);
            var node = start;

            if (visited[node])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;
            bool isFind = false;

            while (queue.Count > 0 && !isFind)
            {
                var edge = queue.Dequeue();

                if(edge == end)
                {
                    PrintResult(path, end);
                    break;
                }

                foreach (var child in graph[edge])
                {
                    if (!visited[child])
                    {
                        path[child] = edge;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static void PrintResult(int[] path, int endDestination)
        {
            var stack = new Stack<int>();
            var edge = endDestination;

            while (edge != -1)
            {
                stack.Push(edge);
                edge = path[edge];
            }

            Console.WriteLine($"Shortest path length is: {stack.Count - 1}");
            Console.WriteLine(String.Join(" ", stack));
        }

        private static void FillGraph(int edges)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new HashSet<int>();
            }

            for (int node = 0; node < edges; node++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = line[0];
                var secondNode = line[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }
        }
    }
}
