namespace Artillery.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportGunDto
    {
        public string GunType { get; set; }

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public string Range { get; set; }
    }
}