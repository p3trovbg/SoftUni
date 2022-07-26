namespace ProductShop.DTOs.Product
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportSoldProductShortInfoDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
