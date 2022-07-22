using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace _05._Break_Cycles
{
    internal class Program
    {
        private static SortedDictionary<string, List<string>> graph;
        private static HashSet<string> cycles;
        private static List<string> results;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            graph = new SortedDictionary<string, List<string>>();
            cycles = new HashSet<string>();
            results = new List<string>();

            FillGraph(rows);

            foreach (var node in graph)
            {
                var from = node.Key;

                for (int child = 0; child < node.Value.Count; child++)
                {

                    bool removed = graph[from].Remove(child) && graph[child].Remove(from);
                    if (!removed)
                    {
                        continue;
                    }

                    if (DFS(from, child))
                    {
                        Console.WriteLine($"{from} - {child}");
                    }
                    else
                    {
                        graph[from].Add(child);
                        graph[child].Add(from);
                    }
                }
             
                }
            }

            Console.WriteLine($"Edges to remove: {results.Count}");
            Console.WriteLine(String.Join(Environment.NewLine, results));
        }

        private static bool DFS(string start, string destination)
        {

            var queue = new Queue<string>();
            queue.Enqueue(start);
            HashSet<string> visited = new HashSet<string> { start };
    
            while (queue.Count > 0)
            {
                var edge = queue.Dequeue();
                if (edge == destination)
                {
                    return true;
                }

                foreach (var child in graph[edge])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static void FillGraph(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                var row = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var parent = row[0];
                var children = row[1]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .OrderBy(x => x)
                    .ToList();

                graph.Add(parent, children);
            }
        }
    }
}
