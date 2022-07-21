using System;
using System.Collections.Generic;
using System.Linq;

namespace Cycles
{
    internal class Program
    {
        private static Dictionary<string, HashSet<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, HashSet<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();
            FillGraph();

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }
            }
            catch (InvalidOperationException)
            {

                Console.WriteLine("Acyclic: No");
                return;
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static void FillGraph()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                var data = line.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var from = data[0];
                var to = data[1];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new HashSet<string>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new HashSet<string>());
                }

                graph[from].Add(to);
            }
        }

        private static void DFS(string node)
        {
            if(cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if(visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }
    }
}
