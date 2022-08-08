using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1.00, 100.00)]
        public decimal Price { get; set; }

        [Range(1, 10)]
        [Required]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        [ForeignKey(nameof(PlayId))]
        public Play Play { get; set; }

        [Required]
        public int TheatreId { get; set; }

        [ForeignKey(nameof(TheatreId))]
        public Theatre Theatre { get; set; }


    }
}