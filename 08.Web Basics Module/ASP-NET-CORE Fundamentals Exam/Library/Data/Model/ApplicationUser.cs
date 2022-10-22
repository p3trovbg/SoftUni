namespace Library.Data.Model
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ApplicationUserBooks = new HashSet<ApplicationUserBook>();
        }
        public ICollection<ApplicationUserBook> ApplicationUserBooks { get; set; }
    }
}
