using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Max_Flow
{
    public class Program
    {
        private static int[] parents; 
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var graph = ReadGraph(n);

            var source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            parents = new int[n];
            Array.Fill(parents, -1);

            var maxFlow = 0;
            while (BFS(graph, source, destination, parents))
            {
                var minFlow = int.MaxValue;

                var to = destination;
                var from = parents[to];

                minFlow = FindMinFlow(to, from, graph);

                maxFlow += minFlow;

                DecreaseAllFlows(graph, minFlow, to, from);
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void DecreaseAllFlows(int[][] graph, int minFlow, int to, int from)
        {
            while (to != -1 && from != -1)
            {
                graph[from][to] -= minFlow;

                to = parents[to];
                from = parents[to];
            }
        }

        private static int FindMinFlow(int to, int from, int[][] graph)
        {
            var minFlow = int.MaxValue;
            while (to != -1 && from != -1)
            {
                minFlow = Math.Min(minFlow, graph[from][to]);

                to = parents[to];
                from = parents[to];
            }

            return minFlow;
        }

        private static bool BFS(int[][] graph, int source, int destination, int[] parents)
        {
            var visited = new bool[graph.Length];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph[node].Length; child++)
                {
                    if (!visited[child] && graph[node][child] > 0)
                    {
                        visited[child] = true;
                        parents[child] = node;
                        queue.Enqueue(child);
                    }
                }
            }

            return visited[destination];
        }

        private static int[][] ReadGraph(int n)
        {
            var matrix = new int[n][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = line;
            }

            return matrix;
        }
    }
}
