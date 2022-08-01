using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement("categoryId")]
        public int? CategoryId { get; set; }

        [XmlElement("productId")]
        public int? ProductId { get; set; }
    }
}
