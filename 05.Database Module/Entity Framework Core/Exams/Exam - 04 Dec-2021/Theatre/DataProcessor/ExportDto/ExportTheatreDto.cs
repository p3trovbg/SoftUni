using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theatre.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTheatreDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Halls")]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("TotalIncome")]
        public decimal TotalInCome { get; set; }

        public List<ExportTicketDto> Tickets { get; set; }
    }
}
