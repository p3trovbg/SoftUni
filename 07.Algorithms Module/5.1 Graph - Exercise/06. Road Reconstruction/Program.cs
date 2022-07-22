using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadConstruction
{   
    public class Edge
    {
        public Edge(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int First { get; set; }
        public int Second { get; set; }

        public override string ToString()
        {
            return $"{First} {Second}";
        }
    }
    internal class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            graph = new List<int>[rows];

            var roads = int.Parse(Console.ReadLine());
            edges = new List<Edge>();
            

            FillGraph(rows, roads);
            var result = new List<string>();

            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];
                DFS(0);

                if (visited.Contains(false))
                {
                    var first = Math.Min(edge.First, edge.Second);
                    var second = Math.Max(edge.First, edge.Second);
                    var newEdge = new Edge(first, second);

                    result.Add(newEdge.ToString());
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
            Console.WriteLine("Important streets:");
            Console.WriteLine(String.Join(Environment.NewLine, result));
        }

        private static void DFS(int node)
        {
            if(visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }

        private static void FillGraph(int rows, int roads)
        {
            for (int i = 0; i < rows; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < roads; i++)
            {
                var edgeParts = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeParts[0];
                var second = edgeParts[1];

                graph[first].Add(second);
                graph[second].Add(first);

                edges.Add(new Edge(first, second));
            }
        }
    }
}
