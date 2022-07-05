using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public int MinutesPlayed { get; set; }
    }
}
