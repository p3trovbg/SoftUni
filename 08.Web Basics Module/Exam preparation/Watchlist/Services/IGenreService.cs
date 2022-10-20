namespace Watchlist.Services
{
    using System.Collections.Generic;
    using Watchlist.Models;

    public interface IGenreService
    {
        Task<IEnumerable<GenreViewModel>> All();
    }
}
