using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price => Songs.Sum(x => x.Price);

        public int ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
