using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Cheap_Town_Tour
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Cost { get; set; }
    }

    public class Program
    {
        private static List<Edge> edges;
        private static int[] parent;

        static void Main(string[] args)
        {
            edges = new List<Edge>();

            int towns = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());

            FillGraph(streets);

            parent = new int[towns];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            var totalCost = 0;
            foreach (var edge in edges.OrderBy(x => x.Cost))
            {
                var firstEdgeRoot = FindRoot(edge.First);
                var secondEdgeRoot = FindRoot(edge.Second);

                if(firstEdgeRoot == secondEdgeRoot)
                {
                    continue;
                }

                parent[firstEdgeRoot] = secondEdgeRoot;
                totalCost += edge.Cost;
            }

            Console.WriteLine($"Total cost: {totalCost}");
        }

        private static int FindRoot(int node)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }

        private static void FillGraph(int streets)
        {
            for (int i = 0; i < streets; i++)
            {
                var streetData = Console.ReadLine()
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var first = streetData[0];
                var second = streetData[1];
                var cost = streetData[2];

                edges.Add(new Edge
                {
                    First = first,
                    Second = second,
                    Cost = cost,
                });
            }
        }
    }
}
