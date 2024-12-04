namespace LibraVerse.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Extensions;
    using LibraVerse.Core.Models.QueryModels.Book;
    using LibraVerse.Core.Models.QueryModels.BookStore;

    public class BookStoreController : BaseController
    {
        private readonly IBookStoreService bookStoreService;
        private readonly IBookService bookService;

        public BookStoreController(IBookStoreService bookStoreService, IBookService bookService)
        {
            this.bookStoreService = bookStoreService;
            this.bookService = bookService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllBookStoresQueryModel model)
        {
            var allEvents = await bookStoreService.AllAsync(
                model.SearchTerm,
                model.Status,
                model.CurrentPage,
                model.BookStoresPerPage);

            model.TotalBookStoresCount = allEvents.TotalBookStoresCount;
            model.BookStores = allEvents.BookStores;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBookStore = await bookStoreService.DetailsAsync(id);

            if (information != currentBookStore.GetInformation())
            {
                return BadRequest();
            }

            return View(currentBookStore);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllBooks([FromQuery] AllBooksQueryModel model, int id)
        {
            var allBooks = await bookStoreService.AllBooksAsync(
                id,
                model.Genre,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage);

            model.TotalBooksCount = allBooks.TotalBooksCount;
            model.Books = allBooks.Books;
            model.BookStoreId = id;
            model.Genres = await bookService.AllGenresNamesAsync();

            return View(model);
        }
    }
}