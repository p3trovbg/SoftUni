using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var membersBySide = new Dictionary<string, List<string>>();

            //Key: forceUser, Value: forceSide
            var members = new Dictionary<string, string>();
            while (true)
            {

                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    //{forceSide} | {forceUser}

                    string[] data = input.Split(" | ");
                    string forceSide = data[0];
                    string forceUser = data[1];

                    if (members.ContainsKey(forceUser))
                    {
                        continue;
                    }

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                        membersBySide.Add(forceSide, new List<string>());
                    }
                     membersBySide[forceSide].Add(forceUser);
                     members.Add(forceUser, forceSide);
                }
                else
                {
                    //{forceUser} -> {forceSide}
                    string[] data = input.Split(" -> ");
                    string forceUser = data[0];
                    string forceSide = data[1];

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                      membersBySide.Add(forceSide, new List<string>());
                    }

                    if (members.ContainsKey(forceUser))
                    {
                        string oldSide = members[forceUser];
                        membersBySide[oldSide].Remove(forceUser);
                        membersBySide[forceSide].Add(forceUser);

                        members[forceUser] = forceSide;
                    }
                    else
                    {
                        membersBySide[forceSide].Add(forceUser);
                        members.Add(forceUser, forceSide);
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var filter = membersBySide
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var sides in filter)
            {
                Console.WriteLine($"Side: {sides.Key}, Members: {sides.Value.Count}");
                sides.Value.Sort();
                foreach (var member in sides.Value)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
