namespace Artillery.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Gun")]
    public class XmlExportGunDto
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public string GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public string BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public string Range { get; set; }

        [XmlArray("Countries")]
        public ExportCountryDto[] Countries { get; set; }
    }
}
