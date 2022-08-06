namespace Footballers.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [JsonObject]
    public class ImportTeamDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"[A-z\d \.-]*")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public string Trophies { get; set; }

        public List<int> Footballers { get; set; }
    }
}
