namespace Library.Service
{
    using Library.Data;
    using Library.Data.Model;
    using Library.Models.Books;
    using Microsoft.EntityFrameworkCore;
    public class BookService : IBookService
    {
        public readonly LibraryDbContext dbContext;
        public BookService(LibraryDbContext context)
        {
            this.dbContext = context;
        }

        public async Task Add(ImportBookViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToCollection(int bookId, string userId)
        {
            var user = await this.dbContext.Users
                .Include(x => x.ApplicationUserBooks)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new NullReferenceException("User doesn't exist!");
            }

            if (user.ApplicationUserBooks.Any(x => x.BookId == bookId))
            {
                return;
                //throw new ArgumentException("This book has already been added!");
            }

            user.ApplicationUserBooks.Add(new ApplicationUserBook { BookId = bookId, ApplicationUserId = userId });
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> All()
        {
            return await this.dbContext.Books
                 .Include(x => x.Category)
                 .Select(x =>
                         new AllBookViewModel
                         {
                             Id = x.Id,
                             Title = x.Title,
                             Author = x.Author,
                             ImageUrl = x.ImageUrl,
                             Rating = x.Rating,
                             Category = x.Category.Name,
                         })
                 .ToListAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> Mine(string userId)
        {
            return await this.dbContext.Books
             .Where(x => x.ApplicationUserBooks.Any(x => x.ApplicationUserId == userId))
             .Include(x => x.Category)
             .Select(x =>
                     new MineBookViewModel
                     {
                         Id = x.Id,
                         Title = x.Title,
                         Author = x.Author,
                         ImageUrl = x.ImageUrl,
                         Category = x.Category.Name,
                         Description = x.Description,
                     })
             .ToListAsync();
        }

        public async Task RemoveFromCollection(int bookId, string userId)
        {
            var user = await this.dbContext.Users.Include(x => x.ApplicationUserBooks).FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new NullReferenceException("User doesn't exist!");
            }

            var book = user.ApplicationUserBooks.FirstOrDefault(x => x.BookId == bookId);

            if (book == null)
            {
                throw new ArgumentException("The book doesn't exist!");
            }

            user.ApplicationUserBooks.Remove(book);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
