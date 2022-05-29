using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Team>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] infoTeam = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = infoTeam[0];
                string teamName = infoTeam[1];
               
                try
                {
                    if (action == "Team")
                    {
                        teams.Add(teamName, new Team(teamName));
                        continue;
                    }
                    else if (action == "Add")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = infoTeam[2];
                        int endurance = int.Parse(infoTeam[3]);
                        int sprint = int.Parse(infoTeam[4]);
                        int dribble = int.Parse(infoTeam[5]);
                        int passing = int.Parse(infoTeam[6]);
                        int shooting = int.Parse(infoTeam[7]);
                        teams[teamName].AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                    }
                    else if (action == "Remove")
                    {
                        string playerName = infoTeam[2];
                        teams[teamName].RemovePlayer(teamName, playerName);
                    }
                    else if (action == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{teamName} - {teams[teamName].Raiting}");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }           
            }
        }
    }
}
