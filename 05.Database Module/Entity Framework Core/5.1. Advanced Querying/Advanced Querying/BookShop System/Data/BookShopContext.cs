using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext(DbContextOptions options) 
            : base(options)
        {
        }

        public BookShopContext()
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookCategory>(bc =>
            {
                bc.HasKey(bc => new { bc.BookId, bc.CategoryId });
            });

            builder.Entity<Author>(a =>
            {
                a.Property(a => a.FirstName).IsUnicode(true);
                a.Property(a => a.LastName).IsUnicode(true);
            });

            builder.Entity<Book>(b =>
            {
                b.Property(b => b.Title).IsUnicode(true);
                b.Property(b => b.Description).IsUnicode(true);
            });

            builder.Entity<Category>(c =>
            {
                c.Property(c => c.Name).IsUnicode(true);
            });
        }
    }
}
