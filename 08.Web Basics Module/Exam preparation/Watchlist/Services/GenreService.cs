using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class GenreService : IGenreService
    {
        public readonly WatchlistDbContext context;

        public GenreService(WatchlistDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<GenreViewModel>> All()
        {
            return await this.context.Genres.Select(x => new GenreViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToArrayAsync();
        }
    }
}
