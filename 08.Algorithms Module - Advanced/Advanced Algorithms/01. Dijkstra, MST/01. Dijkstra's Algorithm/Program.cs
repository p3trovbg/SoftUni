namespace _01.Dijkstra_s_Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        /*Read the input information
        Fill dictionary with all nodes
        Fill visited and parent array
        Find shortest path in graph with dijkstra
         -> 1. Create priority queue with initial node.
         -> 2. Create loop while the queue has elements.
               - If the min node is positive infinity, this mean that there arent't paths and we should break the loop.
               - If the min node is equal to the end node, we should break the loop so as we will reduce repeats.
         -> 3. Get all children on the current node extracted by the queue.
               - We must select that which is not equal to the min node.
               - If the node distance is positive infinity, that mean we find this node for the first time and we should add in the bag.
               - Add new distance
               - If the new distance is smaller than old, we should overwrite the distance and save the parent and rearrange the queue.
        Print custom result */


        private static Dictionary<int, List<Edge>> nodes = new Dictionary<int, List<Edge>>();
        private static double[] distances;
        private static int[] parents;

        static void Main(string[] args)
        {
            nodes = new Dictionary<int, List<Edge>>();
            int nodeCount = int.Parse(Console.ReadLine());

            FillGraph(nodeCount);

            var biggestNode = nodes.Keys.Max();
            distances = new double[biggestNode + 1];
            parents = new int[biggestNode + 1];

            Array.Fill(distances, double.PositiveInfinity);
            Array.Fill(parents, -1);

            int startNode = int.Parse(s: Console.ReadLine());
            int endNode = int.Parse(s: Console.ReadLine());

            distances[startNode] = 0;

            FindShortestPathInGraph(startNode, endNode);

            PrintResult(endNode);
        }

        private static void PrintResult(int endNode)
        {
            if (double.IsPositiveInfinity(distances[endNode]))
            {
                Console.WriteLine("There is no such path.");
                return;
            }

            Console.WriteLine(distances[endNode]);
            var path = new Stack<int>();
            var parent = endNode;

            while (parent != -1)
            {
                path.Push(parent);
                parent = parents[parent];
            }

            Console.WriteLine(String.Join(" ", path));
        }

        private static void FindShortestPathInGraph(int startNode, int endNode)
        {
            var priorityQueue = new PriorityQueue<int, int>(Comparer<int>.Create((f, s) => (int)(distances[f] - distances[s])));
            //var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distances[f] - distances[s])));
            priorityQueue.Enqueue(startNode, startNode);

            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.Dequeue();

                if (double.IsPositiveInfinity(minNode))
                {
                    break;
                }

                if (minNode == endNode)
                {
                    break;
                }

                foreach (var edge in nodes[minNode])
                {
                    var otherNode = minNode == edge.First ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(distances[otherNode]))
                    {
                        priorityQueue.Enqueue(otherNode, otherNode);
                    }

                    var newDistance = distances[minNode] + edge.Weight;

                    if (newDistance < distances[otherNode])
                    {
                        parents[otherNode] = minNode;
                        distances[otherNode] = newDistance;

                        priorityQueue = new PriorityQueue<int, int>(priorityQueue.UnorderedItems, Comparer<int>.Create((f, s) => (int)(distances[f] - distances[s])));
                    }
                }
            }
        }

        private static void FillGraph(int nodeCount)
        {
            for (int i = 0; i < nodeCount; i++)
            {
                int[] nodeInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = nodeInfo[0];
                var secondNode = nodeInfo[1];
                var weight = nodeInfo[2];

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight,
                };

                if (!nodes.ContainsKey(firstNode))
                {
                    nodes.Add(firstNode, new List<Edge>());
                }

                if (!nodes.ContainsKey(secondNode))
                {
                    nodes.Add(secondNode, new List<Edge>());
                }

                nodes[firstNode].Add(edge);
                nodes[secondNode].Add(edge);
            }
        }
    }
}