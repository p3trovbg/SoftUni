using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Reflection;
using Wintellect.PowerCollections;

namespace _03._Travel_Optimizer
{
    public class Edge
    {
        public int Start { get; set; }

        public int End { get; set; }

        public int Weight { get; set; }
    }
    public class Program
    {
        private static List<Edge>[] graph;
        private static double[] distances;
        private static bool[] stops;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodes];

            ReadGraph();

            int start = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());
            int stopsCount = int.Parse(Console.ReadLine());

            distances = new double[nodes + 1];
            stops = new bool[nodes + 1];

            for (int i = 0; i < nodes + 1; i++)
            {
                distances[i] = double.PositiveInfinity;
            }

            distances[start] = 0;
            stops[start] = true;

            FindShortestPath(start, destination, stopsCount);

            PrintResult(start, destination, stopsCount);
        }

        private static void PrintResult(int start, int destination, int stopsCount)
        {
            if (double.IsPositiveInfinity(distances[destination]))
            {
                Console.WriteLine("There is no such path.");
                return;
            }
            else if(stopsCount == 0)
            {
                Console.WriteLine(start + " " + destination);
                return;
            }

            var result = new List<int>();

            for (int i = 0; i < stops.Length; i++)
            {
                if (stops[i])
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", result));
        }

        private static void FindShortestPath(int start, int destination, int stopsCount)
        {
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((s, e) => distances[s].CompareTo(distances[e])));
            var currentStops = 0;
            priorityQueue.Add(start);

            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.RemoveFirst();

                if (double.IsPositiveInfinity(minNode))
                {
                    break;
                }

                if(minNode == destination)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    if (double.IsPositiveInfinity(distances[edge.End]))
                    {
                        priorityQueue.Add(edge.End);
                    }

                    var newDistance = distances[minNode] + edge.Weight;

                    if (newDistance < distances[edge.End])
                    {
                        currentStops++;
                        stops[edge.End] = currentStops <= stopsCount + 1 ? true : false;
                        distances[edge.End] = newDistance;

                        priorityQueue
                            = new OrderedBag<int>(priorityQueue, Comparer<int>.Create((s, e) => distances[s].CompareTo(distances[e])));
                    }
                }
            }
        }

        private static void ReadGraph()
        {
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<Edge>();
            }

            for (int node = 0; node < graph.Length; node++)
            {
                var data = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                graph[data[0]].Add(new Edge
                {
                    Start = data[0],
                    End = data[1],
                    Weight = data[2],
                });
            }
        }
    }
}
