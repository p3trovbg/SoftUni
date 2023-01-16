using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;

namespace _09._Big_Trip
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
        private static double[] distance;
        private static int[] prev; 

        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<Edge>>();

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            FillGraph(edges);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance = new double[nodes + 1];
            Array.Fill(distance, double.NegativeInfinity);
            distance[source] = 0;

            prev = new int[nodes + 1];
            Array.Fill(prev, -1);
            var sortedNode = TropologicalSorting();

            FindLongestPath(sortedNode);
            PrintResult(destination);
        }

        private static void PrintResult(int destination)
        {
            Console.WriteLine(distance[destination]);
            var path = new Stack<int>();
            while(destination != -1)
            {
                path.Push(destination);
                destination = prev[destination];
            }

            Console.WriteLine(String.Join(" ", path));
        }

        private static void FindLongestPath(Stack<int> sortedNode)
        {
            while (sortedNode.Count > 0)
            {
                var node = sortedNode.Pop();
                foreach (var child in graph[node])
                {
                    var newDistance = distance[child.From] + child.Weight;

                    if(newDistance > distance[child.To])
                    {
                        prev[child.To] = child.From;
                        distance[child.To] = newDistance;
                    }
                }
            }
        }

        private static Stack<int> TropologicalSorting()
        {
            var path = new Stack<int>();
            var visited = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                DFS(node, path, visited);
            }

            return path;
        }

        private static void DFS(int node, Stack<int> path, HashSet<int> visited)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child.To, path, visited);
            }

            path.Push(node);
        }

        private static void FillGraph(int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];

                if(!graph.ContainsKey(from))
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
                    Weight = edgeData[2]
                });
            }
        }
    }
}
