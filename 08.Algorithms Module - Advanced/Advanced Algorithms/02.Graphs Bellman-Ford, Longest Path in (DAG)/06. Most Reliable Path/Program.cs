using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _06._Most_Reliable_Path
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
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.NegativeInfinity;
            }
            distance[source] = 100;

            prev = new int[nodes + 1];
            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = -1;
            }

            FindMostReabilityPath(source, destination);

            PrintResult(destination);
        }

        private static void PrintResult(int destination)
        {
            Console.WriteLine($"Most reliable path reliability: {distance[destination]:f2}%");

            var path = new Stack<int>();
            var node = destination;

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            Console.WriteLine(String.Join(" -> ", path));
        }

        private static void FindMostReabilityPath(int source, int destination)
        {
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distance[s] - distance[f])));
            priorityQueue.Add(source);

            while (priorityQueue.Count > 0)
            {
                var maxNode = priorityQueue.RemoveFirst();

                if (double.IsNegativeInfinity(distance[maxNode]))
                {
                    break;
                }

                if (maxNode == destination)
                {
                    break;
                }

                foreach (var edge in graph[maxNode])
                {
                    var otherNode = maxNode == edge.First ? edge.Second : edge.First;

                    if (double.IsNegativeInfinity(distance[otherNode]))
                    {
                        priorityQueue.Add(otherNode);
                    }

                    var newDistance = distance[maxNode] * edge.Weight / 100;

                    if (newDistance > distance[otherNode])
                    {
                        prev[otherNode] = maxNode;
                        distance[otherNode] = newDistance;

                        priorityQueue = 
                            new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, s) => (int)(distance[s] - distance[f])));
                    }
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

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2]; 

                if(!graph.ContainsKey(first))
                {
                    graph.Add(first, new List<Edge>());
                }

                if(!graph.ContainsKey(second))
                {
                    graph.Add(second, new List<Edge>());
                }

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    Weight = weight
                };

                graph[first].Add(edge);
                graph[second].Add(edge);
            }
        }
    }
}
