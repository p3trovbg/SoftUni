namespace ProductShop.DTOs.Category
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    [JsonObject]
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }
    }
}
