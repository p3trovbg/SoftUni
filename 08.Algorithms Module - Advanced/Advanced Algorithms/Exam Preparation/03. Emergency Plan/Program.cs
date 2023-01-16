using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03._Emergency_Plan
{
    public class Edge
    {
        public Edge(int roomA, int roomB, TimeSpan time)
        {
            RoomA = roomA;
            RoomB = roomB;
            Time = time;
        }

        public int RoomA { get; set; }

        public int RoomB { get; set; }

        public TimeSpan Time { get; set; }
    }
    public class Program
    {
        private static List<Edge>[] graph;
        private static TimeSpan[] distances;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            // On the first input line the number of rooms N will be given.Rooms will be numbered from 0 to N-1.
            // On the second input line the the exit rooms will be given in the format "E1 E2 … En".
            // On the third input line the number of connections C between rooms will be given.
            // On the next C lines connections will be given in the format "RA RB T", denoting the time it takes to go from room A to room B(applies for both directions).
            // On the last line you will be given the time T in which all rooms must be evacuated. 

            int rooms = int.Parse(Console.ReadLine());
            var exitRooms = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int connections = int.Parse(Console.ReadLine());

            ReadGraph(rooms, connections);

            distances = new TimeSpan[rooms];
            parent = new int[rooms];
            visited = new bool[rooms];

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    visited[node] = true;
                    FillDistancesAndParentArray();
                    FindShortestTimeToExit(node, exitRooms);
                }

                ;
            }

            ;
        }

        private static void FindShortestTimeToExit(int node, List<int> exitRooms)
        {
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
            distances[node] = TimeSpan.Zero;
            priorityQueue.Add(node);

            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.RemoveFirst();

                if (TimeSpan.MaxValue == distances[minNode])
                {
                    return;
                }
                if (exitRooms.Contains(minNode))
                {
                    return;
                }

                foreach (var edge in graph[minNode])
                {
                    if (TimeSpan.MaxValue == distances[edge.RoomB])
                    {
                        priorityQueue.Add(edge.RoomB);
                    }

                    var newTime = distances[minNode] + edge.Time;

                    if(newTime < distances[edge.RoomB])
                    {
                        distances[edge.RoomB] = newTime;
                        parent[edge.RoomB] = minNode;

                        priorityQueue =
                            new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
                    }
                }
            }
        }

        private static void FillDistancesAndParentArray()
        {
            for (int i = 0; i < distances.Length; i++)
            {
                parent[i] = -1;
                distances[i] = TimeSpan.MaxValue;
            }
        }

        private static void ReadGraph(int rooms, int connections)
        {
            graph = new List<Edge>[rooms];

            for (int i = 0; i < rooms; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < connections; i++)
            {
                var roomData = Console.ReadLine().Split();

                var roomA = int.Parse(roomData[0]);
                var roomB = int.Parse(roomData[1]);
                var time = TimeSpan.Parse(roomData[2]);

                graph[roomA].Add(new Edge(roomA, roomB, time));
            }
        }
    }
}
