using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Wintellect.PowerCollections;

namespace _02.Problem
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
        private static List<Edge> forestEdges;
        private static HashSet<int> forestNodes;

        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<Edge>>();
            forestEdges = new List<Edge>();
            forestNodes = new HashSet<int>();

            FillGraph();
            ;
            foreach (var node in graph.Keys)
            {
                if (!forestNodes.Contains(node))
                {
                    Prim(node);
                }
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            var totalLength = 0;
            foreach (var edge in forestEdges.OrderBy(x => x.Weight))
            {
                Console.WriteLine($"{edge.First} {edge.Second}");
                totalLength += edge.Weight;
            }

            Console.WriteLine(totalLength);
        }

        private static void Prim(int node)
        {
            forestNodes.Add(node);
            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));
            bag.AddMany(graph[node]);

            while (bag.Count > 0)
            {
                var minEdge = bag.RemoveFirst();
                var newEdge = -1;

                if (forestNodes.Contains(minEdge.First) &&
                   !forestNodes.Contains(minEdge.Second))
                {
                    newEdge = minEdge.Second;
                    forestNodes.Add(minEdge.Second);
                }

                if (!forestNodes.Contains(minEdge.First) &&
                   forestNodes.Contains(minEdge.Second))
                {
                    newEdge = minEdge.First;
                    forestNodes.Add(minEdge.First);
                }

                if (newEdge == -1)
                {
                    continue;
                }

                bag.AddMany(graph[newEdge]);
                forestNodes.Add(newEdge);
                forestEdges.Add(minEdge);

            }
        }

        private static void FillGraph()
        {
            int tumors = int.Parse(Console.ReadLine());
            int edgeCounts = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgeCounts; i++)
            {
                var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                var firstNode = input[0];
                var secondNode = input[1];
                var weight = input[2];

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

                var firstOtherEdge = graph[firstNode].FirstOrDefault(x => x.First == firstNode && x.Second == secondNode);
                if (firstOtherEdge != null)
                {
                    graph[firstNode].Remove(firstOtherEdge);
                    graph[firstNode].Add(edge);

                    graph[secondNode].Remove(firstOtherEdge);
                    graph[secondNode].Add(edge);

                    continue;
                }

                var secondOtherEdge = graph[firstNode].FirstOrDefault(x => x.First == firstNode && x.Second == secondNode);
                if (secondOtherEdge != null)
                {
                    graph[firstNode].Remove(secondOtherEdge);
                    graph[firstNode].Add(edge);

                    graph[secondNode].Remove(secondOtherEdge);
                    graph[secondNode].Add(edge);

                    continue;
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }
    }
}
