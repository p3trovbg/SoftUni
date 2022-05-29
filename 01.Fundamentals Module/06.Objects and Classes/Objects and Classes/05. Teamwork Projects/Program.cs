using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace _05._Teamwork_Projects
{
    class Team
    {
        public Team()
        {
            Members = new List<string>();
        }
        public string TeamLeader { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(rotations);

            for (int i = 0; i < rotations; i++)
            {
                string[] date = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);
                string teamLeader = date[0];
                string teamName = date[1];


                Team isTeam = IsTeam(teamName, teams);
                if (isTeam != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (IsLeader(teamLeader, teams))
                {
                    Console.WriteLine($"{teamLeader} cannot create another team!");
                    continue;
                }

                Team team = new Team()
                {
                    TeamLeader = teamLeader,
                    TeamName = teamName
                };
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {teamLeader}!");
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of assignment")
                {
                    break;
                }

                string[] data = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string member = data[0];
                string teamName = data[1];
                Team isTeam = IsTeam(teamName, teams);
                if (isTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsMember(member, teams))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }

                isTeam.Members.Add(member);
            }

            List<Team> sort = teams
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();
            foreach (var team in sort)
            {
                if (team.Members.Count == 0)
                {
                    break;
                }
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.TeamLeader}");

                List<string> sortedMembers = team.Members
                    .OrderBy(t => t)
                    .ToList();

                foreach (var members in sortedMembers)
                {
                    Console.WriteLine($"-- {members}");
                }
            }


            List<Team> endTeams = teams
                .Where(m => m.Members.Count == 0)
                .OrderBy(t => t.TeamName)
                .ToList();

            Console.WriteLine("Teams to disband:");
            foreach (var team in endTeams)
            {
                Console.WriteLine(team.TeamName);

            }
        }

        private static Team IsTeam(string teamName, List<Team> teams)
        {
            foreach (Team team in teams)
            {
                if (team.TeamName == teamName)
                {
                    return team;
                }
            }
            return null;
        }

        static bool IsMember(string member, List<Team> teams)
        {
            foreach (var team in teams)
            {
                if (team.TeamLeader == member)
                {
                    return true;
                }

                foreach (var members in team.Members)
                {
                    if (members == member)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool IsLeader(string teamLeader, List<Team> currentTeam)
        {
            foreach (var item in currentTeam)
            {
                if (item.TeamLeader == teamLeader)
                {
                    return true;
                }

            }
            return false;
        }
    }
}