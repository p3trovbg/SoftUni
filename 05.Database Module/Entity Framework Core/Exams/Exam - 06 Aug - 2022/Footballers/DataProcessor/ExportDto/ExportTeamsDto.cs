namespace Footballers.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportTeamsDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Footballers")]
        public ExportFootballerDto[] Footballers { get; set; }
    }
}
