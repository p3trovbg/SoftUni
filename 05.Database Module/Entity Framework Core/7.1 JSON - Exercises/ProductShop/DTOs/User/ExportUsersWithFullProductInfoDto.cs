namespace ProductShop.DTOs.User
{
    using Newtonsoft.Json;
    using Product;

    [JsonObject]
    public class ExportUsersWithFullProductInfoDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("soldProducts")]
        public ExportSoldProductsFullInfoDto SoldProductsInfo { get; set; }
    }
}
