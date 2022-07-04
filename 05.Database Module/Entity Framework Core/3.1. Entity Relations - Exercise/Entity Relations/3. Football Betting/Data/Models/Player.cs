using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        //PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }

        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }

        public bool IsInjured { get; set; }
    }
}
