namespace Library.Service
{
    using Library.Models.Books;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> All();

        Task<IEnumerable<MineBookViewModel>> Mine(string userId);

        Task Add(ImportBookViewModel model);

        Task AddToCollection(int bookId, string userId);

        Task RemoveFromCollection(int bookId, string userId);
    }
}
