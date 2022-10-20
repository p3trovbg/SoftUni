using Watchlist.Models;

namespace Watchlist.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> All();

        Task<IEnumerable<MovieViewModel>> Watched(string userId);

        Task Add(ImportMovieViewModel model);

        Task AddToCollection(string userId, int movieId);

        Task RemoveFromCollection(string userId, int movieId);
    }
}
