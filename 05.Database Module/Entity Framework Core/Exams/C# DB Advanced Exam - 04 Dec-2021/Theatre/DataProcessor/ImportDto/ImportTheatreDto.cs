
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTheatreDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        public int NumberOfHalls { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }

        public List<ImportTicketDto> Tickets { get; set; }
    }
}
