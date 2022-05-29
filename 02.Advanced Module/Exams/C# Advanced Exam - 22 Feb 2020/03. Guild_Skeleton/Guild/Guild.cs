using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild (string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count + 1 <= Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return false;
            }
            else
            {
                roster.Remove(player);
                return true;
            }
        }
        public void PromotePlayer(string name)
        {
            roster.FirstOrDefault(x => x.Name == name && x.Rank != "Member").Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            roster.FirstOrDefault(x => x.Name == name && x.Rank != "Trial").Rank = "Trial";
        }
        //Method KickPlayersByClass(string class) - removes all the players by the given class and returns all players from that class as an array
        public Player[] KickPlayersByClass(string typeClass)
        {
            Player[] players = roster.FindAll(x => x.Class == typeClass).ToArray();
            roster.RemoveAll(x => x.Class == typeClass);
            return players;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public int Count => roster.Count();
        public string Name { get; set; }
        public int Capacity { get; set; }

        private List<Player> roster;
    }
}
