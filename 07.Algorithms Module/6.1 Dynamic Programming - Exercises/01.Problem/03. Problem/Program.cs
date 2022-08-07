using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();

            FillGraph(edgesCount);

            int start = int.Parse(Console.ReadLine());
            BFS(start);

            //Result
            Console.WriteLine(string.Join(" ", visited.OrderBy(x => x)));        
        }

        private static void BFS(int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited.Remove(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        visited.Remove(child);
                        queue.Enqueue(child);
                    }
                }
            }

        }

        private static void FillGraph(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeParts = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

                var from = edgeParts[0];
                var to = edgeParts[1];

                if(!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<int>());
                    visited.Add(from);
                }
                
                if(!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<int>());
                    visited.Add(to);
                }

                graph[from].Add(to);
            }
        }
    }
}
