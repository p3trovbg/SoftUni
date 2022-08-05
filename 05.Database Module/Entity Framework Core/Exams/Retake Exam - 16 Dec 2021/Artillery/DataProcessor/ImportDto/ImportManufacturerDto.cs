namespace Artillery.DataProcessor.ImportDto
{
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
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
