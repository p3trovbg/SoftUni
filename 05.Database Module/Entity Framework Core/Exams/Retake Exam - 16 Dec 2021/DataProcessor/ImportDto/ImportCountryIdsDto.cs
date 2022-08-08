namespace Artillery.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    
    [JsonObject]
    public class ImportCountryIdsDto
    {
        [JsonRequired]
        public int Id { get; set; }
    }
}