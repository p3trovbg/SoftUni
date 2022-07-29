using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Supplier
{

    [JsonObject]
    public class ImportSupplierDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isImporter")]
        public bool IsImporter { get; set; }
    }
}
