namespace Artillery.Data.Models
{

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    public class Country
    {
        public Country()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns  { get; set; }
    }
}
