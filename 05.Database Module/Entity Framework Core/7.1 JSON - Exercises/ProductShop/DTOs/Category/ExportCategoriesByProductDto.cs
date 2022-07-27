using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Category
{
    [JsonObject]
    public class ExportCategoriesByProductDto
    {
        [JsonProperty("category")]
        public string Name { get; set; }

        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [JsonProperty("averagePrice")]
        public string AveragePrice { get; set; }

        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}
