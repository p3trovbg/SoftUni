namespace Library.Service
{
    using Library.Views;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategories();

    }
}
