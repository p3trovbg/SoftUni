using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Wintellect.PowerCollections;

namespace _01._Black_Friday
{
    public class Edge
    {
        public Edge(int first, int second, int time)
        {
            First = first;
            Second = second;
            Time = time;
        }

        public int First { get; set; }

        public int Second { get; set; }

        public int Time { get; set; }
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
            var time = 0;
            foreach (var node in graph.Keys)
            {
                if (!forestNodes.Contains(node))
                {
                     time = Prim(node);
                    
                }
            }

            Console.WriteLine(time);
        }

        private static int Prim(int node)
        {
            var totalTime = 0;
            forestNodes.Add(node);
            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Time - s.Time));
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

                totalTime += minEdge.Time;
            }

            return totalTime;
        }

        private static void FillGraph()
        {
            int nodes = int.Parse(Console.ReadLine());
            int edgeCounts = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgeCounts; i++)
            {
                var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                var firstNode = input[0];
                var secondNode = input[1];
                var time = input[2];

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Edge>());
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge(firstNode, secondNode, time);

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }
    }
}
