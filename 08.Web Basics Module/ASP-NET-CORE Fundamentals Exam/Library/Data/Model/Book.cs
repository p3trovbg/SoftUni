namespace Library.Data.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Policy;
    public class Book
    {
        public Book()
        {
            this.ApplicationUserBooks = new HashSet<ApplicationUserBook>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<ApplicationUserBook> ApplicationUserBooks { get; set; }
    }
}