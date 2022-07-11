using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


    }
}
