using System;
using System.Collections.Generic;

namespace Salary
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            FillGraph();

            int totalSum = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                totalSum += DFS(i);
            }


            Console.WriteLine(totalSum);
        }

        private static int DFS(int node)
        {
            if (visited[node])
            {
                return -1;
            }

            if (graph[node].Count == 0)
            {
                return 1;
            }

            var sum = 0;

            foreach (var child in graph[node])
            {
                sum += DFS(child);
            }

            return sum;
        }

        private static void FillGraph()
        {
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                var node = Console.ReadLine();

                for (int j = 0; j < node.Length; j++)
                {
                    if (node[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }
        }
    }
}
