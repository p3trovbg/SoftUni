using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> numbers = new List<int>(first.Count + second.Count);
            int limit = 0;
            bool flag = false;
            int lastIndex = 0;
            if (first.Count > second.Count)
            {
                limit = second.Count;
                flag = true;
            }
            else if (first.Count == second.Count)
            {
                limit = first.Count;
            }
            else
            {
                limit = first.Count;
            }
            //ПРЕНАРЕЖДАНЕ
            for (int i = 0; i < limit; i++)
            {
                numbers.Add(first[i]);
                numbers.Add(second[i]);
            }

            if (flag && limit < first.Count + second.Count - 1)
            {
                for (int i = limit; i < first.Count; i++)
                {
                    numbers.Add(first[i]);
                }
            }
            else
            {
                for (int i = limit; i < second.Count; i++)
                {
                    numbers.Add(second[i]);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

        }


    }
}