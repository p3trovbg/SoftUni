using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Wintellect.PowerCollections;

namespace _01._Tour_de_Sofia
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }
    public class Program
    {
        private static List<Edge>[] graph;
        private static double[] distances;

        static void Main(string[] args)
        {
            int junctions = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());
            int startNode = int.Parse(Console.ReadLine());

            graph = new List<Edge>[junctions];
            ReadGraph(junctions, streets);

            distances = new double[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                distances[i] = double.PositiveInfinity;
            }

            FindShortestPath(startNode);
            PrintResult(startNode);
        }

        private static void PrintResult(int startNode)
        {
            if (double.IsPositiveInfinity(distances[startNode]))
            {
                Console.WriteLine(distances.Count(x => !double.IsPositiveInfinity(x)) + 1);
            }
            else
            {
                Console.WriteLine(distances[startNode]);
            }
        }

        private static void FindShortestPath(int startNode)
        {
            var priorityQueue 
                = new OrderedBag<int>(Comparer<int>.Create((f, t) => distances[f].CompareTo(distances[t])));

            foreach (var child in graph[startNode])
            {
                priorityQueue.Add(child.To);
                distances[child.To] = child.Weight;
            }

            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.RemoveFirst();
                if (double.IsPositiveInfinity(minNode))
                {
                    break;
                }

                if (minNode == startNode)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    if (double.IsPositiveInfinity(distances[edge.To]))
                    {
                        priorityQueue.Add(edge.To);
                    }

                    var newDistance = distances[minNode] + edge.Weight;
                    
                    if (newDistance < distances[edge.To])
                    {
                        
                        distances[edge.To] = newDistance;

                        priorityQueue 
                            = new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, t) => distances[f].CompareTo(distances[t])));
                    }
                }
            }
        }

        private static void ReadGraph(int junctions, int streets)
        {
            for (int i = 0; i < junctions; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < streets; i++)
            {
                var junctionData = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

                var from = junctionData[0];
                var to = junctionData[1];
                var weight = junctionData[2];

                graph[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = weight,
                });
            }
        }
    }
}
