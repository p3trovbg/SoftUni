using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Kruskal_s_Algorithm
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Edge> edges;
        private static List<Edge> forest;
        private static int[] parent;
        static void Main(string[] args)
        {
            edges = new List<Edge>();
            forest = new List<Edge>();

            var lines = int.Parse(Console.ReadLine());

            int maxNode = -1;

            for (int i = 0; i < lines; i++)
            {
                var nodeInfo = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                edges.Add(new Edge
                {
                    First = nodeInfo[0],
                    Second = nodeInfo[1],
                    Weight = nodeInfo[2]
                });

                maxNode = Math.Max(maxNode, nodeInfo[0]);
                maxNode = Math.Max(maxNode, nodeInfo[1]);
            }

            parent = new int[maxNode + 1];

            for (int node = 0; node < parent.Length; node++)
            {
                parent[node] = node;
            }

            var sortedNodes = edges
                .OrderBy(e => e.Weight)
                .ToArray();

            foreach (var node in sortedNodes)
            {
                var firstRoot = FindRoot(node.First);
                var secondRoot = FindRoot(node.Second);

                if(firstRoot == secondRoot)
                {
                    continue;
                }

                parent[firstRoot] = parent[secondRoot];
                forest.Add(node);
            }

            PrintResult();

        }

        private static void PrintResult()
        {
            foreach (var edge in forest)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static int FindRoot(int node)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }
    }
}
