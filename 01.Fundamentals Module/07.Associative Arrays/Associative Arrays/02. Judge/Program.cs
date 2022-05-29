using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace _02._Judge
{
    class Contest
    {
        public string ContestName { get; set; }
        public new Dictionary<string, int> DataUser { get; set; }

        public Contest(string name)
        {
            ContestName = name;
            DataUser = new Dictionary<string, int>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dates = new Dictionary<string, Contest>();
            var individualUsers = new Dictionary<string, int>();
            while (true)
            {
                bool flag = false;
                string input = Console.ReadLine();
                if (input == "no more time")
                {
                    break;
                }
                string[] data = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                string contest = data[1];
                int points = int.Parse(data[2]);
                
                //Chek for exists contest
                if (!dates.ContainsKey(contest))
                {
                    //Add new contest
                    dates.Add(contest, new Contest(contest));
                }

                //We initialize contest.
                Contest theContest =dates[contest];

                //Chek for same username.
                if (!theContest.DataUser.ContainsKey(name))
                {
                    theContest.DataUser.Add(name, points);
                }
                
                //Chek for individual user
                if (!individualUsers.ContainsKey(name))
                {
                    individualUsers.Add(name, points);
                }
                else
                {
                    individualUsers[name] += points;
                }

                //Chek for points on current username.
                if (theContest.DataUser[name] < points)
                {
                    theContest.DataUser[name] = points;
                    individualUsers[name] = points;
                }

            }

            foreach (var contest in dates)
            {
                int index = 0;
                Console.WriteLine($"{contest.Value.ContestName}: {contest.Value.DataUser.Count} participants");

                var users = contest.Value.DataUser.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
                foreach (var currentUser in users)
                {
                    index++;
                    Console.WriteLine($"{index}. {currentUser.Key} <::> {currentUser.Value}");
                }
            }
            int idx = 1;
            Console.WriteLine("Individual standings:");
            foreach (var currentUser in individualUsers.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{idx}. {currentUser.Key} -> {currentUser.Value}");
                idx++;
            }
        }
    }
}
