using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Topological_Sorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> predecessors;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            predecessors = new Dictionary<string, int>();

            FillGraph(n);
            FindAllPredecssors();
            var result = TopologicalSort();

            if(result != null)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", result)}");
            }
        }

        private static List<string> TopologicalSort()
        {
            var result = new List<string>();

            while (predecessors.Count > 0)
            {
                var dependecy = predecessors.FirstOrDefault(x => x.Value == 0).Key;

                if (dependecy == null)
                {
                    break;
                }

                predecessors.Remove(dependecy);
                result.Add(dependecy);

                foreach (var child in graph[dependecy])
                {
                    predecessors[child]--;
                }
            }

            if(predecessors.Count != 0)
            {
                Console.WriteLine("Invalid topological sorting");
                return null;
            }

            return result;
        }

        private static void FindAllPredecssors()
        {
            foreach (var kvp in graph)
            {
                var p = kvp.Key;
                var children = kvp.Value;

                if(!predecessors.ContainsKey(p))
                {
                    predecessors[p] = 0;
                }

                foreach (var child in children)
                {
                    if (!predecessors.ContainsKey(child))
                    {
                        predecessors.Add(child, 0);
                    }
                    predecessors[child]++;
                }
            }
        }

        private static void FillGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(" ->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                if(line.Length == 1)
                {
                    graph.Add(line[0], new List<string>());
                    continue;
                }

                var p = line[0];
                var children = line[1]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                graph[p] = children.ToList();
            }
        }
    }
}
