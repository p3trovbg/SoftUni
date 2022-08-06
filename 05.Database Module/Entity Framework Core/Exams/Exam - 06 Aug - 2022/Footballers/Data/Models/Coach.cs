namespace Footballers.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Coach
    {
        public Coach()
        {
            Footballers = new HashSet<Footballer>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public virtual ICollection<Footballer> Footballers { get; set; }
    }
}