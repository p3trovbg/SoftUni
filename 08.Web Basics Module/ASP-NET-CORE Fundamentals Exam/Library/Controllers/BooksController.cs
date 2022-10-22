namespace Library.Controllers
{
    using Library.Models.Books;
    using Library.Service;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Security.Claims;

    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BooksController(
            IBookService movieService,
            ICategoryService categoryService)
        {
            this.bookService = movieService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            var books = await this.bookService.All();
            var model = new AllBookListViewModel { Books = books };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ImportBookViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            model.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.bookService.Add(model);

            return this.RedirectToAction("All", "Books");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ImportBookViewModel();
            var categories = await this.categoryService.AllCategories();
            model.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            return this.View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var books = await this.bookService.Mine(userId);
            var model = new MineBookListViewModel { Books = books };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.bookService.AddToCollection(bookId, userId);


            return this.RedirectToAction("All", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.bookService.RemoveFromCollection(bookId, userId);


            return this.RedirectToAction("Mine", "Books");
        }
    }
}
