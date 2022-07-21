using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrix
{
    internal class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static Dictionary<char, int> areas = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            graph = new char[row, col];
            visited = new bool[row, col];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j] = line[j];
                }
            }

            FindAllAreas();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Areas: {areas.Values.Sum()}");
            var result = areas.OrderBy(x => x.Key);

            foreach (var area in result)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void FindAllAreas()
        {
            for (int row = 0; row < graph.GetLength(0); row++)
            {
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    var area = graph[row, col];
                    if (visited[row, col])
                    {
                        continue;
                    }
                    DFS(row, col, graph[row, col]);

                    if(!areas.ContainsKey(area))
                    {
                        areas.Add(area, 0);
                    }

                    areas[area]++;
                }
            }
        }

        private static void DFS(int row, int col, char target)
        {
            if (row < 0 || row >= graph.GetLength(0) ||
                col < 0 || col >= graph.GetLength(1))
            {
                return;
            }

            if (graph[row, col] != target)
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }


            visited[row, col] = true;

            DFS(row, col + 1, target);
            DFS(row, col - 1, target);
            DFS(row + 1, col, target);
            DFS(row - 1, col, target);
        }
    }
}
