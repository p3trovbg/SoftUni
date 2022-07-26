namespace ProductShop.DTOs.User
{
    using System.Linq;
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportUsersInfoDto
    {
        [JsonProperty("usersCount")]
        public int UsersCount
            => this.Users.Any() ? this.Users.Length : 0;

        [JsonProperty("users")]
        public ExportUsersWithFullProductInfoDto[] Users { get; set; }
    }
}
