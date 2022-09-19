using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _08._Undefined
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
        private static int[] parent;
        private static double[] distance;
        private static bool isNegativeCycle = false;

        static void Main(string[] args)
        {
            graph = new List<Edge>();
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            FillGraph(edges);

            parent = new int[nodes + 1];
            Array.Fill(parent, -1);

            distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance[source] = 0;

            FindShortPath(nodes);
            PrintResult(destination);
        }

        private static void PrintResult(int node)
        {
            if(isNegativeCycle)
            {
                Console.WriteLine("Undefined");
                return;
            }

            var path = new Stack<int>();
            var endDestination = node;
            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            Console.WriteLine(String.Join(" ", path));
            Console.WriteLine(distance[endDestination]);
        }

        private static void FindShortPath(int nodes)
        {
            for (int i = 0; i < nodes - 1; i++)
            {
                bool isUpdate = false;
                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        parent[edge.To] = edge.From;
                        isUpdate = true;
                    }
                }
                if (!isUpdate)
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
                    return;
                }
            }
        }

        private static void FillGraph(int edges)
        {
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
                    Weight = edgeData[2],
                });
            }
        }
    }
}
