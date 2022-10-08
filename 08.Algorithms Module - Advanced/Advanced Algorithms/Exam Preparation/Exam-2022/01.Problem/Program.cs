using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.Problem
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }
    public class Program
    {
        //project select
        private static Dictionary<int, List<Edge>> graph;
        private static double[] distances;
        private static int[] parents;

        static void Main(string[] args)
        {
            int depots = int.Parse(Console.ReadLine());
            int tracks = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<Edge>>();

            var startAndEnd = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ReadGraph(tracks);
            
            distances = new double[graph.Keys.Count];
            parents = new int[graph.Keys.Count];

            for (int i = 0; i < graph.Keys.Count; i++)
            {
                distances[i] = double.PositiveInfinity;
                parents[i] = -1;
            }

            distances[startAndEnd[0]] = 0;

            FindShortestPath(startAndEnd[0], startAndEnd[1]);

            PrintResult(startAndEnd[1]);
        }

        private static void PrintResult(int destination)
        {
            var path = new Stack<int>();
            var totalDestination = distances[destination];
            while (destination != -1)
            {
                path.Push(destination);
                destination = parents[destination];
            }

            Console.WriteLine(String.Join(" ", path));
            Console.WriteLine(totalDestination);
        }

        private static void FindShortestPath(int start, int destination)
        {
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, t) => distances[f].CompareTo(distances[t])));
            priorityQueue.Add(start);

            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.RemoveFirst();

                if (double.IsPositiveInfinity(distances[minNode]))
                {
                    return;
                }

                if(minNode == destination)
                {
                    return;
                }

                foreach (var edge in graph[minNode])
                {
                    var otherNode = minNode == edge.First ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(distances[otherNode]))
                    {
                        priorityQueue.Add(otherNode);
                    }

                    var newDistance = distances[minNode] + edge.Weight;

                    if(newDistance < distances[otherNode])
                    {
                        parents[otherNode] = minNode;
                        distances[otherNode] = newDistance;

                        priorityQueue =
                            new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, t) => distances[f].CompareTo(distances[t])));
                    }
                }
            }
        }

        private static void ReadGraph(int tracks)
        {
            for (int i = 0; i < tracks; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var first = line[0];
                var second = line[1];
                var weight = line[2];

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
                    Weight = weight,
                };

                graph[first].Add(edge);
                graph[second].Add(edge);
            }
        }
    }
}
