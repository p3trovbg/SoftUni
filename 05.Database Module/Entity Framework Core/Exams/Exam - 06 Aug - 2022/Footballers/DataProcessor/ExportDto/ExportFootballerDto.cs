namespace Footballers.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportFootballerDto
    {
        [JsonProperty("FootballerName")]
        public string Name { get; set; }

        public string ContractStartDate { get; set; }

        public string ContractEndDate { get; set; }

        public string BestSkillType { get; set; }

        public string PositionType { get; set; }
    }
}
