using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        private int raiting;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Raiting
        {
            get => players.Count != 0 ? (int)Math.Round(players.Average(x => x.Stats)) : 0;        
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string teamName, string playerName)
        {
            var player = players.FirstOrDefault(x => x.Name == playerName);
            if (player == null)
            {
                Console.WriteLine($"Player {playerName} is not in {teamName} team.");
            }
            else
            {
                players.Remove(player);
            }
        }

    }
}
