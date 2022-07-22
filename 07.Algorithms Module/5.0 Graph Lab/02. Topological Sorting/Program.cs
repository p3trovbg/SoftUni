using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Topological_Sorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> predecessors;
        private static bool[] visited;
        private Action<string> consolePrintResult;


        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            predecessors = new Dictionary<string, int>();
            visited = new bool[n];

            FillGraph(n);
            GetPredecessorsCount();
            ;
        }

        private static void GetPredecessorsCount()
        {
            foreach (var kvp in graph)
            {
                var edge = kvp.Key;
                var children = kvp.Value;

                if(!predecessors.ContainsKey(edge))
                {
                    predecessors.Add(edge, 0);
                }

                foreach (var child in children)
                {
                    if(!predecessors.ContainsKey(child))
                    {
                        predecessors.Add(child, 0);
                    }

                    predecessors[child]++;
                }
            }
        }

        private static void DFS()
        {
            throw new NotImplementedException();
        }

        private static void FillGraph(int n)
        {
            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var edge = line[0];
                if (line.Length == 1)
                {
                    graph[edge] = new List<string>();
                    continue;
                }

                var children = line[1]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if(!graph.ContainsKey(edge))
                {
                    graph[edge] = new List<string>();
                }

                graph[edge] = children;
            }
        }
    }
}
