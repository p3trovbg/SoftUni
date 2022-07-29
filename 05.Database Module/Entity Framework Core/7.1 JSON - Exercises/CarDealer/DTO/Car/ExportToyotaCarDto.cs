using Newtonsoft.Json;

namespace CarDealer.DTO.Car
{
    [JsonObject]
    public class ExportToyotaCarDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
    }
}
