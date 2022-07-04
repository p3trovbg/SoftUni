
using System;
using System.ComponentModel.DataAnnotations;


namespace _3._Football_Betting.Data.Models
{
    public class PlayerStatistic
    {
        //GameId, PlayerId, ScoredGoals, Assists, MinutesPlayed
        [Key]
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public DateTime MinutesPlayed { get; set; }
    }
}
