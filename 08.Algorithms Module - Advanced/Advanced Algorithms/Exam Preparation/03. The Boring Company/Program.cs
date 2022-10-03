using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Wintellect.PowerCollections;

namespace _03._The_Boring_Company
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static HashSet<int> forest;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            int initialConnections = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<Edge>>();
            ReadGraph(edges);

            ReadInitialConnections(initialConnections);

            var minBudget = Prim();

            Console.WriteLine($"Minimum budget: {minBudget}");
        }

        private static int Prim()
        {
            var minBudget = 0;
            var priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

            foreach (var node in forest)
            {
                priorityQueue.AddMany(graph[node]);
            }

            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.RemoveFirst();
                var newNode = -1;

                if(forest.Contains(minNode.First) &&
                   !forest.Contains(minNode.Second))
                {
                    newNode = minNode.Second;
                }

                if (!forest.Contains(minNode.First) &&
                    forest.Contains(minNode.Second))
                {
                    newNode = minNode.First;
                }

                if(newNode == -1)
                {
                    continue;
                }

                priorityQueue.AddMany(graph[newNode]);
                forest.Add(newNode);

                minBudget += minNode.Weight;
            }

            return minBudget;
        }

        private static void ReadInitialConnections(int initialConnections)
        {
            forest = new HashSet<int>();

            for (int i = 0; i < initialConnections; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                forest.Add(line[0]);
                forest.Add(line[1]);
            }
        }

        private static void ReadGraph(int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var input = Console.ReadLine().Split();

                var firstNode = int.Parse(input[0]);
                var secondNode = int.Parse(input[1]);
                var weight = int.Parse(input[2]);

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Edge>());
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }
    }
}
