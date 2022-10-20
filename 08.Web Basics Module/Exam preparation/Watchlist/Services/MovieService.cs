using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        public readonly WatchlistDbContext context;
        public MovieService(WatchlistDbContext context)
        {
            this.context = context;
        }

        public async Task Add(ImportMovieViewModel model)
        {
            var movie = new Movie
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId,
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task AddToCollection(string userId, int movieId)
        {
            var user = await this.context.Users.Include(x => x.UsersMovies).FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new NullReferenceException("User doesn't exist!");
            }

            if (user.UsersMovies.Any(x => x.MovieId == movieId)) 
            {
                return;
                //throw new ArgumentException("This movie has already been added!");
            }

            user.UsersMovies.Add(new UserMovie { MovieId = movieId, UserId = userId });
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> All()
        {
            return await this.context.Movies
                .Include(x => x.Genre)
                .Select(x =>
                        new MovieViewModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Director = x.Director,
                            ImageUrl = x.ImageUrl,
                            Genre = x.Genre.Name,
                            Rating = x.Rating,
                        })
                .ToListAsync();
        }

        public async Task RemoveFromCollection(string userId, int movieId)
        {
            var user = await this.context.Users.Include(x => x.UsersMovies).FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new NullReferenceException("User doesn't exist!");
            }

            var movie = user.UsersMovies.FirstOrDefault(x => x.MovieId == movieId);

            if (movie == null)
            {
                throw new ArgumentException("The movie doesn't exist!");
            }

            user.UsersMovies.Remove(movie);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> Watched(string userId)
        {
            return await this.context.Movies
               .Where(x => x.UsersMovies.Any(x => x.UserId == userId))
               .Include(x => x.Genre)
               .Select(x =>
                       new MovieViewModel
                       {
                           Id = x.Id,
                           Title = x.Title,
                           Director = x.Director,
                           ImageUrl = x.ImageUrl,
                           Genre = x.Genre.Name,
                           Rating = x.Rating,
                       })
               .ToListAsync();
        }
    }
}
