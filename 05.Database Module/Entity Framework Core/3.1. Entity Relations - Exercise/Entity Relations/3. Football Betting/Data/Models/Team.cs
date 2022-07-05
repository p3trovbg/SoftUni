using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models 
{
    public class Team
    {
        //•	Team – TeamId, Name, LogoUrl, Initials (JUV, LIV, ARS…),
        //Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
        public Team()
        {
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
            Players = new HashSet<Player>();
        }
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }


        [Required]
        public int PrimaryKitColorId { get; set; }

        [ForeignKey(nameof(PrimaryKitColorId))]
        public Color PrimaryKitColor { get; set; }

        [Required]
        public int SecondaryKitColorId { get; set; }

        [ForeignKey(nameof(SecondaryKitColorId))]
        public Color SecondaryKitColor { get; set; }

        [Required]
        public int TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; }

        //Team can have many HomeGames and many AwayGames
        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> HomeGames { get; set; }


        [InverseProperty(nameof(Game.AwayTeam))]
        public virtual ICollection<Game> AwayGames { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
