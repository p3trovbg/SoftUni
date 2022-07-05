using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{

    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }
    }
}
