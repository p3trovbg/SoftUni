using System;
namespace Artillery.Data.Models
{
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }
        [Key]
        public int Id { get; set; }

        public string ManufacturerName { get; set; }

        public string Founded { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
