using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        //GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result)

        [Key]
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        [Required]
        [ForeignKey(nameof(HomeTeamId))]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [Required]
        [ForeignKey(nameof(AwayTeamId))]
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }
        [Required]

        public decimal HomeTeamBetRate { get; set; }
        [Required]

        public decimal AwayTeamBetRate { get; set; }
        [Required]

        public decimal DrawBetRate { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }


    }
}
