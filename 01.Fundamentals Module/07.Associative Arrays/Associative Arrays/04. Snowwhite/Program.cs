using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataDwarf = new SortedDictionary<string, SortedDictionary<string, int>>();
            var sorted = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Once upon a time")
                {
                    break;
                }
                string[] data = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string color = data[1];
                int physic = int.Parse(data[2]);

                if (!dataDwarf.ContainsKey(color))
                {
                    dataDwarf.Add(color, new SortedDictionary<string, int>());
                    sorted.Add(name + " " + color, physic);
                }

                if (!dataDwarf[color].ContainsKey(name))
                {
                    dataDwarf[color].Add(name, physic);
                    sorted[name + " " + color] = physic;
                }

                if (dataDwarf.ContainsKey(color) && dataDwarf[color].ContainsKey(name))
                {
                    if (dataDwarf[color][name] < physic)
                    {
                        dataDwarf[color][name] = physic;
                        sorted[name +" " + color] = physic;
                    }
                }
            }
            var sortedDwarf = sorted
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => sorted.Where(y => y.Key.Split(" ")[1] == x.Key.Split(" ")[1])
                    .Count());
            foreach (var dwarf in sortedDwarf)
            {
                string color = dwarf.Key.Split(" ")[1];
                string name = dwarf.Key.Split(" ")[0];
                Console.WriteLine($"({color}) {name} <-> {dwarf.Value}");
            }
        }
    }
}
