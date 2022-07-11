using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        //o AuthorId

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength (50)]
        public string LastName { get; set; }
    }
}
