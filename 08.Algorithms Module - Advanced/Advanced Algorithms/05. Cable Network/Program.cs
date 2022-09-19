using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace _10.CableNetwork
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
        private static HashSet<int> forestNodes;
        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<Edge>>();
            forestNodes = new HashSet<int>();

            int budget = int.Parse(Console.ReadLine());
            int nodes = int.Parse(Console.ReadLine());

            FillGraph();

            var result = Prim(budget);

            Console.WriteLine($"Budget used: {result}");
        }

        private static int Prim(int budget)
        {
            var usedBudget = 0;
            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));
            foreach (var node in forestNodes)
            {
                bag.AddMany(graph[node]);
            }

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

                if (usedBudget + minEdge.Weight > budget)
                {
                    break;
                }

                usedBudget += minEdge.Weight;

                bag.AddMany(graph[newEdge]);
                forestNodes.Add(newEdge);
            }

            return usedBudget;
        }

        private static void FillGraph()
        {
            int edgeCounts = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgeCounts; i++)
            {
                var input = Console.ReadLine()
                .Split();

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

                if(input.Length == 4)
                {
                    forestNodes.Add(firstNode);
                    forestNodes.Add(secondNode);
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }
    }


}
