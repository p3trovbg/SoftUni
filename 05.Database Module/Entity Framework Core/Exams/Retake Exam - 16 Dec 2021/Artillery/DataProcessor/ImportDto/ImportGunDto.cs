namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    [JsonObject]
    public class ImportGunDto
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }

        [Required]
        [Range(typeof(double), "2.00", "35.00")]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Range(1, 100_000)]
        public int Range { get; set; }

        [Required]
        [NotMapped]
        public string GunType { get; set; }

        [Required]
        public int ShellId { get; set; }

        public CountryIdDto[] Countries { get; set; }
    }
}
