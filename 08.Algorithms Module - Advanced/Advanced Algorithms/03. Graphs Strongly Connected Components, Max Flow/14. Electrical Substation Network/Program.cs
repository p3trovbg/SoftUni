using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace _14._Electrical_Substation_Network
{
    public class Program
    {
        private static bool[] visited;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            var graph = new List<int>[nodes];
            var reversedGraph = new List<int>[nodes];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                reversedGraph[i] = new List<int>();
            }

            ReadGraph(edges, graph, reversedGraph);

            var sortedGraph = TropologicalSorting(graph);

            visited = new bool[nodes];
            var components = new List<Stack<int>>();
            while (sortedGraph.Count > 0)
            {
                var node = sortedGraph.Pop();
                if(visited[node])
                {
                    continue;
                }

                var component = new Stack<int>();
                DFS(node, reversedGraph, visited, component);

                components.Add(component);
            }

            foreach (var component in components)
            {
                Console.WriteLine($"{string.Join(", ", component)}");
            }
        }

        private static Stack<int> TropologicalSorting(List<int>[] graph)
        {
            var result = new Stack<int>();
            visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, result);
            }

            return result;
        }

        private static void DFS(int node, List<int>[] graph, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, graph, visited, result);
            }

            result.Push(node);
        }

        private static void ReadGraph(int edges, List<int>[] graph, List<int>[] reverseGraph)
        {
            for (int i = 0; i < edges; i++)
            {
                var nodeData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = nodeData[0];

                for (int child = 1; child < nodeData.Length; child++)
                {
                    var currentChild = nodeData[child];
                    graph[node].Add(currentChild);
                    reverseGraph[currentChild].Add(node);
                }
            }
        }
    }
}
