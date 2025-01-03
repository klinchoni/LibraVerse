﻿namespace LibraVerse.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Extensions;
    using LibraVerse.Core.Models.QueryModels.Book;
    using LibraVerse.Core.Models.QueryModels.BookStore;
    using LibraVerse.Core.Models.ViewModels.Book;

    using System.Security.Claims;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IPublisherService publisherService;

        public BookController(IBookService bookService, IPublisherService publisherService)
        {
            this.bookService = bookService;
            this.publisherService = publisherService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllBooksQueryModel model)
        {
            var allBooks = await bookService.AllAsync(
                model.Genre,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage);

            model.TotalBooksCount = allBooks.TotalBooksCount;
            model.Books = allBooks.Books;
            model.Genres = await bookService.AllGenresNamesAsync();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllBookstoresWithBook(int id, [FromQuery] AllBookStoresQueryModel model)
        {
            var allEvents = await bookService.AllBookstoresWithBook(
                id,
                model.SearchTerm,
                model.Status,
                model.CurrentPage,
                model.BookStoresPerPage);

            model.TotalBookStoresCount = allEvents.TotalBookStoresCount;
            model.BookStores = allEvents.BookStores;

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await bookService.DetailsAsync(id);

            if (information != currentBook.GetInformation())
            {
                return BadRequest();
            }

            return View(currentBook);
        }

        [HttpGet]
        public async Task<IActionResult> MyBooks(string id, [FromQuery] AllBooksQueryModel model)
        {
            var userId = User.Id();

            if (userId != id)
            {
                return Unauthorized();
            }

            var bookCollections = new AllBookCollectionsModel()
            {
                booksUserWantsToRead = await bookService.AllWantToReadBooksIdsByUserIdAsync(
                userId, model.Genre, model.SearchTerm, model.Sorting, model.CurrentPage, model.BooksPerPage),

                booksUserCurrentlyReading = await bookService.AllCurrentlyReadingBooksIdsByUserIdAsync(
                    userId, model.Genre, model.SearchTerm, model.Sorting, model.CurrentPage, model.BooksPerPage),

                booksUserRead = await bookService.AllReadBooksIdsByUserIdAsync(
                    userId, model.Genre, model.SearchTerm, model.Sorting, model.CurrentPage, model.BooksPerPage)
            };

            return View(bookCollections);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsWantToRead(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await bookService.DetailsAsync(id);
            return View(currentBook);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsCurrentlyReading(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await bookService.DetailsAsync(id);
            return View(currentBook);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsRead(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await bookService.DetailsAsync(id);
            return View(currentBook);
        }

        [HttpGet]
        public async Task<IActionResult> WantToRead([FromQuery] AllBooksQueryModel model)
        {
            var userId = User.Id();

            var allBooks = await bookService.AllWantToReadBooksIdsByUserIdAsync(
                userId,
                model.Genre,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage);

            model.TotalBooksCount = allBooks.TotalBooksCount;
            model.Books = allBooks.Books;
            model.Genres = await bookService.AllGenresNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CurrentlyReading([FromQuery] AllBooksQueryModel model)
        {
            var userId = User.Id();

            var allBooks = await bookService.AllCurrentlyReadingBooksIdsByUserIdAsync(
                userId,
                model.Genre,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage);

            model.TotalBooksCount = allBooks.TotalBooksCount;
            model.Books = allBooks.Books;
            model.Genres = await bookService.AllGenresNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Read([FromQuery] AllBooksQueryModel model)
        {
            var userId = User.Id();

            var allBooks = await bookService.AllReadBooksIdsByUserIdAsync(
                userId,
                model.Genre,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage);

            model.TotalBooksCount = allBooks.TotalBooksCount;
            model.Books = allBooks.Books;
            model.Genres = await bookService.AllGenresNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddWantToRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }
            if (await bookService.BookIsInAnotherCollectionAsync(id, userId))
            {
                await bookService.RemoveBookFromAllCollectionsAsync(id, userId);
            }


            await bookService.AddWantToReadBookAsync(id, userId);
            return RedirectToAction(nameof(MyBooks), new { id = userId });
        }

        [HttpGet]
        public async Task<IActionResult> AddCurrentlyReading(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }
            if (await bookService.BookIsInAnotherCollectionAsync(id, userId))
            {
                await bookService.RemoveBookFromAllCollectionsAsync(id, userId);
            }

            await bookService.AddCurrentlyReadingBookAsync(id, userId);
            return RedirectToAction(nameof(MyBooks), new { id = userId });
        }

        [HttpGet]
        public async Task<IActionResult> AddRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }
            if (await bookService.BookIsInAnotherCollectionAsync(id, userId))
            {
                await bookService.RemoveBookFromAllCollectionsAsync(id, userId);
            }

            await bookService.AddReadBookAsync(id, userId);

            if (await bookService.FindBookReviewAsync(User.Id(), id) != null)
            {
                return RedirectToAction(nameof(MyBooks), new { id = userId });
            }

            return RedirectToAction(nameof(BookReviewQuestion), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> BookReviewQuestion(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var bookReviewQuestion = await bookService.BookReviewQuestionAsync(id);

            return View(bookReviewQuestion);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveWantToRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id) || !await bookService.BookIsWantToReadAsync(id, userId))
            {
                return BadRequest();
            }

            await bookService.RemoveWantToReadBookAsync(id, userId);
            return RedirectToAction(nameof(WantToRead));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCurrentlyReading(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id) || !await bookService.BookIsCurrentlyReadingAsync(id, userId))
            {
                return BadRequest();
            }

            await bookService.RemoveCurrentlyReadingBookAsync(id, userId);
            return RedirectToAction(nameof(CurrentlyReading));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id) || !await bookService.BookIsReadAsync(id, userId))
            {
                return BadRequest();
            }

            await bookService.RemoveReadBookAsync(id, userId);
            return RedirectToAction(nameof(Read));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBookReview(int id)
        {
            var bookReview = await bookService.FindBookReviewByIdAsync(id);

            if (bookReview == null)
            {
                return BadRequest();
            }
            if (bookReview.UserId != User.Id() && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var searchedBookReview = await bookService.DeleteBookReviewAsync(id);

            return View(searchedBookReview);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBookReviewConfirmed(int reviewId)
        {
            var bookReview = await bookService.FindBookReviewByIdAsync(reviewId);

            if (bookReview == null)
            {
                return BadRequest();
            }
            if (bookReview.UserId != User.Id() && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var id = await bookService.DeleteBookReviewConfirmedAsync(reviewId);

            return RedirectToAction(nameof(AllReviews), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> AddReview(int id)
        {
            string userId = User.Id();

            var bookReviewForm = new BookReviewAddViewModel()
            {
                BookId = id,
                UserId = userId
            };

            return View(bookReviewForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(BookReviewAddViewModel bookReviewForm)
        {
            if (!ModelState.IsValid)
            {
                return View(bookReviewForm);
            }

            int newBookReviewId = await bookService.AddBookReviewAsync(bookReviewForm, bookReviewForm.UserId, bookReviewForm.BookId);

            int id = bookReviewForm.BookId;
            return RedirectToAction(nameof(AllReviews), new { id });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllReviews(int id, [FromQuery] AllBookReviewsQueryModel model)
        {
            var book = bookService.FindBookByIdAsync(id).Result;
            var currentBookInfo = await bookService.DetailsAsync(id);

            var allBooks = await bookService.AllBookReviewsAsync(
                id,
                book.Title,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ReviewsPerPage);

            model.TotalBookReviewsCount = allBooks.TotalReviewsCount;
            model.BookReviews = allBooks.BookReviews;
            model.BookId = id;
            model.BookTitle = book.Title;
            model.BookInfo = currentBookInfo.GetInformation();

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> BookReviewDetails(int id)
        {
            if (await bookService.FindBookReviewByIdAsync(id) == null)
            {
                return BadRequest();
            }

            var currentBookReview = await bookService.BookReviewDetailsAsync(id);
            return View(currentBookReview);
        }

        [HttpGet]
        public async Task<IActionResult> EditBookReview(int id)
        {
            var bookReview = await bookService.FindBookReviewByIdAsync(id);

            if (bookReview == null)
            {
                return BadRequest();
            }
            if (User.Id() != bookReview.UserId)
            {
                return Unauthorized();
            }

            var bookReviewForm = await bookService.EditBookReviewGetAsync(id);
            return View(bookReviewForm);
        }

        [HttpPost]
        public async Task<IActionResult> EditBookReview(BookReviewEditViewModel bookReviewForm)
        {
            if (bookReviewForm == null)
            {
                return BadRequest();
            }
            if (User.Id() != bookReviewForm.UserId)
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(bookReviewForm);
            }

            var id = bookReviewForm.BookId;
            await bookService.EditBookReviewPostAsync(bookReviewForm);
            return RedirectToAction(nameof(AllReviews), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> ChangePage(int id)
        {
            string userId = User.Id();
            var bookUserIsCurrentlyReading = await bookService.FindBookCurrentlyReadingAsync(id, userId);

            if (bookUserIsCurrentlyReading == null)
            {
                return BadRequest();
            }
            if (User.Id() != bookUserIsCurrentlyReading.UserId)
            {
                return Unauthorized();
            }

            var changePageForm = await bookService.ChangePageGetAsync(id, userId);
            return View(changePageForm);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePage(ChangePageViewModel changePageForm)
        {
            var currentBook = bookService.FindBookByIdAsync(changePageForm.BookId).Result;

            if (changePageForm == null)
            {
                return BadRequest();
            }
            if (User.Id() != changePageForm.UserId)
            {
                return Unauthorized();
            }
            if (changePageForm.CurrentPage > currentBook.Pages)
            {
                ModelState.AddModelError("CurrentPage", "You can't be on an unexisting page!");
            }
            if (!ModelState.IsValid)
            {
                return View(changePageForm);
            }

            int id = currentBook.Id;

            if (changePageForm.CurrentPage == currentBook.Pages)
            {
                await RemoveCurrentlyReading(id);
                await AddRead(id);

                if (await bookService.FindBookReviewAsync(User.Id(), id) == null)
                {
                    return RedirectToAction(nameof(BookReviewQuestion), new { id });
                }
                return RedirectToAction(nameof(MyBooks), new { id = User.Id() });
            }

            await bookService.ChangePagePostAsync(changePageForm);
            return RedirectToAction(nameof(DetailsCurrentlyReading), new { id });
        }
    }
}