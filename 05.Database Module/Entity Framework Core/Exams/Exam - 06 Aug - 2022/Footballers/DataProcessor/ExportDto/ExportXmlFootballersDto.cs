namespace Footballers.DataProcessor.ExportDto
{
    using System.Xml.Serialization;
    [XmlType("Footballer")]
    public class ExportXmlFootballersDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }
    }
}