using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using Wintellect.PowerCollections;
using static System.Net.Mime.MediaTypeNames;

namespace _02._Chain_Lightning
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }
    public class Program
    {
        private static List<Edge>[] graph;
        private static int[] damagesByNeighborhoods;
        static void Main(string[] args)
        {
            //	The first line holds an integer n – the number of neighborhoods
            //•	On the second line, you will receive the number m – the number of distances
            //•	On the third line, l -the number of lightning
            //•	At the next m lines, you will receive the distances: { from neighbourhood}
            //{ to neighbourhood}
            //{ distance}
            //•	At the next l lines, you will receive the lightning strikes: { neighborhood}
            //{ damage}
            //•	The neighborhood will always be numbered from 0 to N -1

            int neighborhoods = int.Parse(Console.ReadLine());
            int distances = int.Parse(Console.ReadLine());
            int ligtiningCount = int.Parse(Console.ReadLine());

            graph = new List<Edge>[neighborhoods];
            damagesByNeighborhoods = new int[neighborhoods];

            for (int i = 0; i < neighborhoods; i++)
            {
                graph[i] = new List<Edge>();
            }

            ReadGraph(distances);

            for (int i = 0; i < ligtiningCount; i++)
            {
                var lightData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int neighborhood = lightData[0];
                int damage = lightData[1];

                Prim(neighborhood, damage);

            }
                Console.WriteLine(damagesByNeighborhoods.Max());
        }

        private static void Prim(int neighborhood, int damage)
        {
            damagesByNeighborhoods[neighborhood] += damage;
            var jumps = new int[graph.Length];
            var tree = new HashSet<int> { neighborhood };
            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

            bag.AddMany(graph[neighborhood]);

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                var newNode = -1;
                var parentNode = -1;

                if (tree.Contains(minNode.First) &&
                    !tree.Contains(minNode.Second))
                {
                    newNode = minNode.Second;
                    parentNode = minNode.First;
                }

                if(tree.Contains(minNode.Second) &&
                   !tree.Contains(minNode.First))
                {
                    newNode = minNode.First;
                    parentNode = minNode.Second;
                }

                if (newNode == -1)
                {
                    continue;
                }

                tree.Add(newNode);
                bag.AddMany(graph[newNode]);
                jumps[newNode] = jumps[parentNode] + 1;
                damagesByNeighborhoods[newNode] += CalculateDamage(damage, jumps[newNode]);
            }
        }

        private static int CalculateDamage(int damage, int jumps)
        {
            for (int i = 0; i < jumps; i++)
            {
                damage /= 2;
            }

            return damage;
        }

        private static void ReadGraph(int distances)
        {
            for (int i = 0; i < distances; i++)
            {
                var data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var edge = new Edge
                {
                    First = data[0],
                    Second = data[1],
                    Weight = data[2],
                };

                graph[edge.First].Add(edge);
                graph[edge.Second].Add(edge);
            }
        }
    }
}
