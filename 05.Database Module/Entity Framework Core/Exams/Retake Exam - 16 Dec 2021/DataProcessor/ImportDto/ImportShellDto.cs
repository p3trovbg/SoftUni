namespace Artillery.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    [XmlType("Shell")]
    public class ImportShellDto
    {
        [Required]
        [Range(2, 1680)]
        [XmlElement("ShellWeight")]
        public double ShellWeight { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Caliber { get; set; }

    }
}
