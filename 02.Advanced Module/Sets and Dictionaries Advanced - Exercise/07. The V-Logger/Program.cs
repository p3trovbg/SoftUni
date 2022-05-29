using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Vloger
    {
        public int Following { get; set; }
        public List<string> Followers { get; set; }
        public Vloger(int following, List<string> followers)
        {
            Following = following;
            Followers = followers;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var vlogers = new Dictionary<string, Vloger>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] data = input.Split();
                string firstName = data[0];
                string action = data[1];
                string secondName = data[2];

                List<string> names = new List<string>();
                if (action == "joined")
                {
                    if (!vlogers.ContainsKey(firstName))
                    {
                        vlogers.Add(firstName, new Vloger(0, names));
                    }
                    else
                    {
                        continue;
                    }
                }

                else if (action == "followed")
                {
                    if (!vlogers.ContainsKey(firstName)
                        || !vlogers.ContainsKey(secondName) ||
                        firstName == secondName)
                    {
                        continue;
                    }
                    if (vlogers[secondName].Followers.Contains(firstName))
                    {
                        continue;
                    }
                    vlogers[secondName].Followers.Add(firstName);
                    vlogers[firstName].Following++;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");
            int idx = 1;
            vlogers = vlogers
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var vloger in vlogers)
            {
                Console.WriteLine($"{idx}. {vloger.Key} : {vloger.Value.Followers.Count} followers, {vloger.Value.Following} following");
                if (idx == 1)
                {
                    foreach (var followers in vloger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {followers}");
                    }
                }
                idx++;
            }
        }
    }
}
