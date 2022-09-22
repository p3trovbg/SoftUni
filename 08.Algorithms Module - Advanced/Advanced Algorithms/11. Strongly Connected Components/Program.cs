using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _11._Strongly_Connected_Components
{
    public class Program
    {
        private static bool[] visited;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            var graph = new List<int>[nodes];
            var reverseGraph = new List<int>[nodes];

            FillGraphs(lines, graph, reverseGraph);

            var sortedGraph = TropologicalSorting(graph);

            var connectedComponents = new List<Stack<int>>();
            visited = new bool[nodes];

            while (sortedGraph.Count > 0)
            {
                var node = sortedGraph.Pop();
                if (visited[node])
                {
                    continue;
                }

                var component = new Stack<int>();

                DFS(node, reverseGraph, component, visited);

                connectedComponents.Add(component);
            }

            Console.WriteLine("Strongly Connected Components:");
            foreach (var component in connectedComponents)
            {
                Console.WriteLine($"{{{string.Join(" ", component)}}}");
            }
        }

        private static Stack<int> TropologicalSorting(List<int>[] graph)
        {
            var result = new Stack<int>();
            visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, result, visited);
            }

            return result;
        }

        private static void DFS(int node, List<int>[] graph, Stack<int> result, bool[] visited)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, graph, result, visited);
            }

            result.Push(node);
        }

        private static void FillGraphs(int lines, List<int>[] graph, List<int>[] reverseGraph)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                reverseGraph[i] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = input[0];
                for (int child = 1; child < input.Length; child++)
                {
                    var currentChild = input[child];
                    graph[node].Add(currentChild);
                    reverseGraph[currentChild].Add(node);
                }
            }
        }
    }
}
