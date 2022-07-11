using BookShop.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Copies { get; set; }

        public decimal Price { get; set; }

        public EditionTypes EditionType { get; set; }

        public AgeRestrictions AgeRestriction { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }
    }
}
