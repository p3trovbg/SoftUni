using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _05._Longest_path_in_DAG
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }
    public class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<Edge>>();
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            FillGraph(edges);
            var sortedNodes = TropologicalSorting();

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            double[] distance = new double[nodes + 1];
            Array.Fill(distance, double.NegativeInfinity);
            distance[source] = 0;

            FindLongestPath(sortedNodes, distance);

            // Print result
            Console.WriteLine(distance[destination]);
        }

        private static void FindLongestPath(Stack<int> sortedNodes, double[] distance)
        {
            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance > distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                    };
                }
            }
        }

        private static Stack<int> TropologicalSorting()
        {
            var result = new Stack<int>();
            var visited = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                DFS(node, result, visited);
            }

            return result;
        }

        private static void DFS(int node, Stack<int> result, HashSet<int> visited)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child.To, result, visited);
            }

            result.Push(node);
        }

        private static void FillGraph(int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = data[0];
                int to = data[1];
                int weight = data[2];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<Edge>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<Edge>());
                }

                graph[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = weight
                });
            }
        }
    }
}
