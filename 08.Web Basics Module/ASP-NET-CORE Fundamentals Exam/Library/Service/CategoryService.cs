namespace Library.Service
{
    using Library.Data;
    using Library.Views;
    using Microsoft.EntityFrameworkCore;
    public class CategoryService : ICategoryService

    {
        private readonly LibraryDbContext dbContext;

        public CategoryService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategories()
        {
            return await this.dbContext.Categories
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();
        }
    }
}
