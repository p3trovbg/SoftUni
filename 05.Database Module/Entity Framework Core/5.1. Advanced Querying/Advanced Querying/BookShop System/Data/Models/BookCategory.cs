using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class BookCategory
    {
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book{ get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

    }
}
