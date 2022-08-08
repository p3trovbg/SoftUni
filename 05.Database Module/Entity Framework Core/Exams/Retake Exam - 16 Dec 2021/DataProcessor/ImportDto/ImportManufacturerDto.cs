namespace Artillery.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    
    [XmlType("Manufacturer")]
    public class ImportManufacturerDto
    {

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        [XmlElement("Founded")]
        public string Founded { get; set; }
    }
}
