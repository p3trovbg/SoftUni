namespace Artillery.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class ExportShellDto
    {
        public double ShellWeight { get; set; }

        public string Caliber { get; set; }

        public List<ExportGunDto> Guns { get; set; }
    }
}
