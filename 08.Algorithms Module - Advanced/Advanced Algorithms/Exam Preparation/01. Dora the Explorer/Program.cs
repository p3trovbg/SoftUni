using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01._Dora_the_Explorer
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Minutes { get; set; }
    }
    public class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static int[] parent;
        private static double[] distances;

        static void Main(string[] args)
        {
            var citiesConnections = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<Edge>>();

            ReadGraph(citiesConnections);

            var minutes = int.Parse(Console.ReadLine());

            var startNode = int.Parse(Console.ReadLine());
            var destiantion = int.Parse(Console.ReadLine());

            var length = graph.Keys.Max();
            parent = new int[length + 1];
            distances = new double[length + 1];

            for (int i = 0; i < length + 1; i++)
            {
                parent[i] = -1;
                distances[i] = double.PositiveInfinity;
            }

            FindShortestPath(startNode, destiantion, minutes);

            Console.WriteLine($"Total time: {distances[destiantion]}");
            var path = new Stack<int>();
            while (destiantion != -1)
            {
                path.Push(destiantion);
                destiantion = parent[destiantion];
            }

            foreach (var value in path)
            {
                Console.WriteLine(value);
            }
        }

        private static void FindShortestPath(int startNode, int destiantion, int minutes)
        {
            distances[startNode] = 0;
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));

            priorityQueue.Add(startNode);


            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.RemoveFirst();

                if (double.IsPositiveInfinity(minNode))
                {
                    break;
                }

                if (minNode == destiantion)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    var otherNode = minNode == edge.First ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(distances[otherNode]))
                    {
                        priorityQueue.Add(otherNode);
                    }

                    var newDistance = distances[minNode] + edge.Minutes;

                    if(newDistance < distances[otherNode])
                    {
                        parent[otherNode] = minNode;
                        distances[otherNode] = otherNode == destiantion ? newDistance : newDistance + minutes;

                        priorityQueue 
                            = new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
                    }
                }
            }
        }

        private static void ReadGraph(int citiesConnections)
        {
            for (int i = 0; i < citiesConnections; i++)
            {
                var data = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var first = data[0];
                var second = data[1];
                var minutes = data[2];

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
                    Minutes = minutes
                };

                graph[first].Add(edge);
                graph[second].Add(edge);
            }
        }
    }
}
