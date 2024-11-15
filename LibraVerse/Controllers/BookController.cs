using System.Globalization;
using LibraVerse.Data;
using LibraVerse.Data.Models;
using LibraVerse.Web.ViewModels.Book;
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
        public IActionResult Create(AddBookInputModel inputModel)
        {
            //Checks if the validation with data annotations was successful
            if (!this.ModelState.IsValid)
            {
                //Render the same form with user entered values + model errors
                return this.View(inputModel);
            }

            bool isReleaseDateValid = DateTime
                .TryParseExact(inputModel.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), "The ReleaseDate must be in the following format: dd/MM/yyyy");
                return this.View(inputModel);
            }

            Book book = new Book()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Author = inputModel.Author,
                Pages = inputModel.Pages,
                Description = inputModel.Description,
            };

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
