using LibraVerse.Data;
using LibraVerse.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraVerse.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraDbContext dbContext;

        public BookController(LibraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> allBooks = dbContext
                .Books
                .ToList();

            return this.View(allBooks); //allBooks is set as object in the view
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
