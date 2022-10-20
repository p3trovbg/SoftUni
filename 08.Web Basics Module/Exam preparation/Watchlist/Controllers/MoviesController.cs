namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Security.Claims;
    using Watchlist.Data.Models;
    using Watchlist.Models;
    using Watchlist.Services;

    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService;
            this.genreService = genreService;
        }

        public async Task<IActionResult> All()
        {
            var movies = await this.movieService.All();
            var model = new MovieListViewModel { Movies = movies };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ImportMovieViewModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View();
            }

            model.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.movieService.Add(model);

            return this.RedirectToAction("All", "Movies");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ImportMovieViewModel();
            var genres = await this.genreService.All();
            model.Genres = genres.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            return this.View(model);
        }

        public async Task<IActionResult> Watched()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movies = await this.movieService.Watched(userId);
            var model = new MovieListViewModel { Movies = movies };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.movieService.AddToCollection(userId, movieId);


            return this.RedirectToAction("All", "Movies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.movieService.RemoveFromCollection(userId, movieId);


            return this.RedirectToAction("Watched", "Movies");
        }
    }
}
