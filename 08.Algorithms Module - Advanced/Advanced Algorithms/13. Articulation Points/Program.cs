using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._Articulation_Points
{
    public class Program
    {
        private static List<int>[] graph;
        private static int[] parents;
        private static int[] depths;
        private static int[] lowpoint;
        private static bool[] visited;
        private static List<int> articulationPoints;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            parents = new int[nodes];
            ReadGraph(nodes, lines);

            visited = new bool[nodes];
            depths = new int[nodes];
            lowpoint = new int[nodes];
            articulationPoints = new List<int>();

            //for (int node = 0; node < graph.Length; node++)
            //{
            //    if (!visited[node])
            //    {
            //        DFS(node, 1);
            //    }
            //}
            DFS(5, 1);

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

        private static void DFS(int node, int depth)
        {
            depths[node] = depth;
            lowpoint[node] = depth;
            visited[node] = true;

            var children = 0;
            bool isArticulationPoint = false;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    parents[child] = node;
                    DFS(child, depth + 1);
                    children++;

                    if (lowpoint[child] >= depth)
                    {
                        isArticulationPoint = true;
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parents[node] != child)
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depths[child]);
                }
            }

            if(isArticulationPoint && parents[node] != -1 ||
                parents[node] == -1 && children > 1)
            {
                articulationPoints.Add(node);
            }
        }

        private static void ReadGraph(int nodes, int lines)
        {
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
                parents[i] = -1;
            }

            for (int i = 0; i < lines; i++)
            {
                var nodeData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = nodeData[0];
                graph[node].AddRange(nodeData.Skip(1));
            }
        }
    }
}
