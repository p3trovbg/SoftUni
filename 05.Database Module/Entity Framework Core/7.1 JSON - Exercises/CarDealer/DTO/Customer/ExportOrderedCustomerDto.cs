using Newtonsoft.Json;
using System;

namespace CarDealer.DTO.Customer
{
    [JsonObject]
    public class ExportOrderedCustomerDto
    {
        public string Name { get; set; }

       [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
