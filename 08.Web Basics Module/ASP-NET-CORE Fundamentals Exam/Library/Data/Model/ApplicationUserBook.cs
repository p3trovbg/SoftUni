namespace Library.Data.Model
{
    public class ApplicationUserBook
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}