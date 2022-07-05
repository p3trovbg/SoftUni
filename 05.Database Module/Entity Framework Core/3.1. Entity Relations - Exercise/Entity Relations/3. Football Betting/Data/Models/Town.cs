using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        public Town()
        {
            Teams = new HashSet<Team>();
        }
        [Key]
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
