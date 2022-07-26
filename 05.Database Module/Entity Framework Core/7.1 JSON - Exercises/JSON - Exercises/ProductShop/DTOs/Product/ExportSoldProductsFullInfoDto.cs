namespace ProductShop.DTOs.Product
{
    using System.Linq;

    using Newtonsoft.Json;

    [JsonObject]
    public class ExportSoldProductsFullInfoDto
    {
        [JsonProperty("count")]
        public int ProductsCount
            => this.SoldProducts.Any() ? SoldProducts.Length : 0;

        [JsonProperty("products")]
        public ExportSoldProductShortInfoDto[] SoldProducts { get; set; }
    }
}
