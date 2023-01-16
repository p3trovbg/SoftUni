using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Bellman_Ford_s_Algorithm
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Edge> graph;
        private static double[] distance;
        private static int[] parent;
        private static bool isNegativeCycle = false;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            FillGraph(edges);

            int startPoint = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);
            distance[startPoint] = 0;

            parent = new int[nodes + 1];
            FindPath(nodes);
            PrintResult(destination);
        }

        private static void PrintResult(int destination)
        {
            if (isNegativeCycle)
            {
                return;
            }

            var path = new Stack<int>();
            var node = destination;
            while (node != 0)
            {
                path.Push(node);
                node = parent[node];
            }

            Console.WriteLine(String.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }

        private static void FindPath(int nodes)
        {
            for (int i = 0; i < nodes - 1; i++)
            {
                var isUpdated = false;
                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;
                    if (newDistance < distance[edge.To])
                    {
                        parent[edge.To] = edge.From;
                        distance[edge.To] = newDistance;
                        isUpdated = true;
                    }
                }

                if (!isUpdated)
                {
                    break;
                }
            }

            foreach (var edge in graph)
            {
                var newDistance = distance[edge.From] + edge.Weight;
                if (newDistance < distance[edge.To])
                {
                    isNegativeCycle = true;
                    Console.WriteLine("Negative Cycle Detected");
                    return;
                }
            }
        }

        private static void FillGraph(int edges)
        {
            graph = new List<Edge>();
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                graph.Add(new Edge
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2]
                });
            }
        }
    }
}
