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

        [HttpPost]
        public IActionResult Create(Book book)
        {
            this.dbContext.Books.Add(book);
            this.dbContext.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);

            //Invalid format for the Id
            if (!isIdValid)
            {
                return this.RedirectToAction("Index");
            }

            Book? book = this.dbContext
                .Books
                .FirstOrDefault(b=>b.Id==guidId);

            //Do not exsit this Guid
            if (book == null)
            { 
                return this.RedirectToAction("Index");
            }

            //Return data for this book if everything is correct
            return this.View(book);
        }
    }
}
