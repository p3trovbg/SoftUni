using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Part
{
    [JsonObject]
    public class ExportPartInfoDto
    {
        public string Name { get; set; }

        public string Price { get; set; }
    }
}
