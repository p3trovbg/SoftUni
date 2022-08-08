namespace Artillery.Data.Models
{
using System.ComponentModel.DataAnnotations.Schema;
    public class CountryGun
    {
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        public int GunId { get; set; }

        [ForeignKey(nameof(GunId))]
        public virtual Gun Gun { get; set; }
    }
}