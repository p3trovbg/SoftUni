using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Range(typeof(decimal), "1.00", "100.00")]
        [Required]
        public string Name { get; set; }

        [Range(typeof(int), "1", "10")]
        [Required]
        public sbyte NumberOfHalls { get; set; }

        [Range(4, 30)]
        [Required]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
