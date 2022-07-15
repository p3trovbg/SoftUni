using System;
using System.Collections.Generic;

namespace _01._Distance_Between_Vertices
{
    internal class Program
    {
        private static HashSet<int>[] graph;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pathCount = int.Parse(Console.ReadLine());

            graph = new HashSet<int>[n];
            FillGraph(n);
        }

        private static void FillGraph(int n)
        {
            //2 - edges
            //2 - relations 
            //1:2
            //2:
            //1 - 2
            //2 - 1

            for (int node = 0; node < n; node++)
            {

            }
        }
    }
}
