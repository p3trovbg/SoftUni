namespace ProductShop.DTOs.User
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    using Newtonsoft.Json;

    [JsonObject]
    public class ImportUserDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        [MinLength(GlobalConstants.UserLastNameMinLength)]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
