using Newtonsoft.Json;

namespace Theatre.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTicketDto
    {
        public decimal Price { get; set; }

        public sbyte RowNumber { get; set; }
    }
}
