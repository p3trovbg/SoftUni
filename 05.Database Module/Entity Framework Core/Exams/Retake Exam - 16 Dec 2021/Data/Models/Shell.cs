namespace Artillery.Data.Models
{
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    public class Shell
    { 
        public Shell()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        public double ShellWeight { get; set; }

        public string Caliber { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
