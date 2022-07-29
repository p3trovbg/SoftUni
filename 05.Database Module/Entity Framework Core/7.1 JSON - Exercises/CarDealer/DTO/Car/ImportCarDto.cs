using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO.Car
{
    [JsonObject]
    public class ImportCarDto
    {
        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("travelledDistance")]
        public int TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartsId { get; set; }
    }
}
