
namespace LibraVerse.Services.Test
{
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Data;
    using LibraVerse.Data.Repository;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.BookUserActions;


    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Enums;
    using LibraVerse.Core.Models.ViewModels.Book;
    using LibraVerse.Core.Services;

    [TestFixture]
    public class BookServiceUnitTests
    {
        private LibraDbContext dbContext;
        private IEnumerable<Book> books;
        private IEnumerable<Genre> genres;

        private IRepository repository;
        private IBookService service;

        //Books
        private Book TheCallOfTheWild;
        private Book ASlavonicBulgarianHistory;
        private Book TheHistoryOfHeridot;
        private Book TheHistoryOfAnArt;
        private Book AroundTheWorldOf80Days;

        //Genres
        private Genre Adventure;
        private Genre History;
        private Genre Historiography;
        private Genre Art;

        //Book Collections
        private BookUserWantToRead bookUserWantToRead;
        private BookUserCurrentlyReading bookUserCurrentlyReading;
        private BookUserRead bookUserRead;

        //Book Reviews
        private BookReview bookReview;


        [SetUp]
        public async Task Setup()
        {
            //Books
            TheCallOfTheWild = new Book()
            {
                Id = 1,
                Title = "The Call of The Wild",
                Author = "Jack London",
                GenreId = 1,
                Description = "The description of The Call of the Wild book",
                Pages = 128,
                YearPublished = 1903,
                Price = 5.00m,
                ImageUrl = "https://i2.helikon.bg/products/4956/05/54956/0658229_b.jpg?t=1732090822",
            };

            ASlavonicBulgarianHistory = new Book()
            {
                Id = 2,
                Title = "A Slavonic-bulgarian history",
                Author = "Paisii Hilendarski",
                GenreId = 3,
                Description = "The history of bulgarians",
                Pages = 240,
                YearPublished = 1762,
                Price = 30.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/i/s/istoria-slavianobylgarska.jpg",
            };

            TheHistoryOfHeridot = new Book()
            {
                Id = 3,
                Title = "The history of Heridot",
                Author = "Heridot",
                GenreId = 2,
                Description = "The description of this book",
                Pages = 810,
                YearPublished = 1888,
                Price = 50.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/h/e/herodot-istoria.jpg",
            };

            TheHistoryOfAnArt = new Book()
            {
                Id = 4,
                Title = "The history of an Art",
                Author = "Nikolay Raynov",
                GenreId = 4,
                Description = "The description of The history of an Art book",
                Pages = 808,
                YearPublished = 2024,
                Price = 98.00m,
                ImageUrl = "https://i2.helikon.bg/products/6357/24/246357/246357_b.jpg?t=1732093233",
            };

            AroundTheWorldOf80Days = new Book()
            {
                Id = 5,
                Title = "Around The World Of 80 Day",
                Author = "Jaul Vern",
                GenreId = 1,
                Description = "The description of this book",
                Pages = 280,
                YearPublished = 1873,
                Price = 25.90m,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/Verne_Tour_du_Monde.jpg/330px-Verne_Tour_du_Monde.jpg",
            };

            //Genres
            Adventure = new Genre()
            {
                Id = 1,
                Name = "Adventure"
            };

            History = new Genre()
            {
                Id = 2,
                Name = "Historiography"
            };

            Historiography = new Genre()
            {
                Id = 3,
                Name = "History"
            };

            Art = new Genre()
            {
                Id = 4,
                Name = "Art"
            };

            books = new List<Book>()
            {
                TheCallOfTheWild, ASlavonicBulgarianHistory, TheHistoryOfHeridot, TheHistoryOfAnArt, AroundTheWorldOf80Days
            };

            genres = new List<Genre>()
            {
               Adventure, History, Historiography, Art
            };

            //Book Collections
            bookUserWantToRead = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 1,
                TimeAdded = DateTime.Now
            };
            bookUserCurrentlyReading = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 2,
                TimeAdded = DateTime.Now
            };
            bookUserRead = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 3,
                TimeAdded = DateTime.Now
            };

            //Book Reviews
            bookReview = new BookReview()
            {
                Id = 1,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title",
                Description = "Review Description",
                Rate = 10
            };

            //In-Memory DB
            var options = new DbContextOptionsBuilder<LibraDbContext>()
                .UseInMemoryDatabase(databaseName: "LibraVerseInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new LibraDbContext(options);

            dbContext.AddRangeAsync(books);
            dbContext.AddRangeAsync(genres);
            dbContext.AddAsync(bookUserWantToRead);
            dbContext.AddAsync(bookUserCurrentlyReading);
            dbContext.AddAsync(bookUserRead);
            dbContext.AddAsync(bookReview);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new BookService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task Test_AllAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllAsync("Historiography");
            var resultTwo = await service.AllAsync("NotAnExistingBook");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 3, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllAsync(null, "The Call");
            var resultTwo = await service.AllAsync(null, "NotAValidSearchTerm");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 1, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllAsync_SortsByNewest()
        {
            // Act
            var booksNewestSorting = await service.AllAsync();
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 3, 2, 1 }));
        }

        [Test]
        public async Task Test_AllAsync_SortsByOldest()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 1, 2, 3, 4, 5 }));
        }

        [Test]
        public async Task Test_AllAsync_SortsByTitleAscending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() {2, 5, 1, 4, 3}));
        }

        [Test]
        public async Task Test_AllAsync_SortsByTitleDescending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 3, 4, 1, 5, 2 }));
        }

        [Test]
        public async Task Test_AllAsync_SortsByAuthorAscending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() {  3, 1, 5, 4, 2 }));
        }

        [Test]
        public async Task Test_AllAsync_SortsByAuthorDescending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() {2, 4, 5, 1, 3 }));
        }

        [Test]
        public async Task Test_AllAsync_SortsByPriceAscending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 1, 5, 2, 3, 4 }));
        }

        [Test]
        public async Task Test_AllAsync_SortsByPriceDescending()
        {
            // Act
            var booksNewestSorting = await service.AllAsync(null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Skip(3).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 3, 2, 5, 1 }));
        }

        [Test]
        public async Task Test_BookExistsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int bookId = 1;
            int nonExistingBookId = -1;

            // Act
            var resultOne = await service.BookExistsAsync(bookId);
            var resultTwo = await service.BookExistsAsync(nonExistingBookId);

            // Assert
            Assert.That(resultOne, Is.EqualTo(true));
            Assert.That(resultTwo, Is.EqualTo(false));
        }

        [Test]
        public async Task Test_FindBookByIdAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int bookId = 1;
            int nonExistingBookId = -1;

            // Act
            var resultOne = await service.FindBookByIdAsync(bookId);
            var resultTwo = await service.FindBookByIdAsync(nonExistingBookId);

            // Assert
            Assert.That(resultOne, Is.Not.Null);
            Assert.That(resultOne.Id, Is.EqualTo(bookId));

            Assert.That(resultTwo, Is.Null);
        }

        [Test]
        public async Task Test_GenreExistsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int genreId = 1;
            int nonExistingGenreId = -1;

            // Act
            var resultOne = await service.GenreExistsAsync(genreId);
            var resultTwo = await service.GenreExistsAsync(nonExistingGenreId);

            // Assert
            Assert.That(resultOne, Is.EqualTo(true));
            Assert.That(resultTwo, Is.EqualTo(false));
        }

        [Test]
        public async Task Test_AllGenresAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllGenresAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(4));
            Assert.That(result.First().Name, Is.EqualTo("Adventure"));
            Assert.That(result.Skip(1).First().Name, Is.EqualTo("Historiography"));
            Assert.That(result.Skip(2).First().Name, Is.EqualTo("History"));
            Assert.That(result.Skip(3).First().Name, Is.EqualTo("Art"));
        }

        [Test]
        public async Task Test_AllGenresNamesAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.AllGenresNamesAsync();
            var expectedResult = new List<string>() { "Adventure", "Historiography", "History", "Art" };

            // Assert
            Assert.That(result.Count(), Is.EqualTo(4));
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task Test_DetailsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var currentBookDetails = new BookViewModel()
            {
                Id = TheCallOfTheWild.Id,
                Title = TheCallOfTheWild.Title,
                Author = TheCallOfTheWild.Author,
                Genre = TheCallOfTheWild.Genre.Name,
                Description = TheCallOfTheWild.Description,
                Pages = TheCallOfTheWild.Pages,
                YearPublished = TheCallOfTheWild.YearPublished,
                Price = TheCallOfTheWild.Price,
                ImageUrl = TheCallOfTheWild.ImageUrl,
                Reviews = new List<BookReview>() { bookReview }
            };

            // Act
            var result = await service.DetailsAsync(TheCallOfTheWild.Id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(currentBookDetails.Id));
            Assert.That(result.Title, Is.EqualTo(currentBookDetails.Title));
            Assert.That(result.Author, Is.EqualTo(currentBookDetails.Author));
            Assert.That(result.Genre, Is.EqualTo(currentBookDetails.Genre));
            Assert.That(result.Description, Is.EqualTo(currentBookDetails.Description));
            Assert.That(result.Pages, Is.EqualTo(currentBookDetails.Pages));
            Assert.That(result.YearPublished, Is.EqualTo(currentBookDetails.YearPublished));
            Assert.That(result.Price, Is.EqualTo(currentBookDetails.Price));
            Assert.That(result.ImageUrl, Is.EqualTo(currentBookDetails.ImageUrl));
            Assert.That(result.Reviews.Count, Is.EqualTo(currentBookDetails.Reviews.Count));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", "Adventure");
            var resultTwo = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", "NotAnExistingBook");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 1, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, "The Call");
            var resultTwo = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, "NotAValidSearchTerm");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 1, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByNewest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksNewestSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser");
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 1 }));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByOldest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksOldestSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksOldestSorting.Books.First().Id,
                booksOldestSorting.Books.Skip(1).First().Id,
                booksOldestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksOldestSorting.Books, Is.Not.Null);
            Assert.That(booksOldestSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 1, 4, 5 }));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByTitleAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleAscendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksTitleAscendingSorting.Books.First().Id,
                booksTitleAscendingSorting.Books.Skip(1).First().Id,
                booksTitleAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksTitleAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksTitleAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 1, 4 }));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByTitleDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleDescendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksTitleDescendingSorting.Books.First().Id,
                booksTitleDescendingSorting.Books.Skip(1).First().Id,
                booksTitleDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksTitleDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksTitleDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 1, 5 }));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByAuthorAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorAscendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksAuthorAscendingSorting.Books.First().Id,
                booksAuthorAscendingSorting.Books.Skip(1).First().Id,
                booksAuthorAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksAuthorAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksAuthorAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 1, 5, 4 }));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByAuthorDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorDescendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksAuthorDescendingSorting.Books.First().Id,
                booksAuthorDescendingSorting.Books.Skip(1).First().Id,
                booksAuthorDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksAuthorDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksAuthorDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 5, 1 }));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByPriceAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceAscendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksPriceAscendingSorting.Books.First().Id,
                booksPriceAscendingSorting.Books.Skip(1).First().Id,
                booksPriceAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksPriceAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksPriceAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 1, 5, 4 }));
        }

        [Test]
        public async Task Test_AllWantToReadBooksIdsByUserIdAsync_SortsByPriceDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserWantToRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceDescendingSorting = await service.AllWantToReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksPriceDescendingSorting.Books.First().Id,
                booksPriceDescendingSorting.Books.Skip(1).First().Id,
                booksPriceDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksPriceDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksPriceDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 5, 1 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", "The History");
            var resultTwo = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", "NotAnExistingBook");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 4, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, "The History");
            var resultTwo = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, "NotAValidSearchTerm");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 4, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByNewest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksNewestSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser");
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 2 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByOldest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksOldestSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksOldestSorting.Books.First().Id,
                booksOldestSorting.Books.Skip(1).First().Id,
                booksOldestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksOldestSorting.Books, Is.Not.Null);
            Assert.That(booksOldestSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 2, 4, 5 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByTitleAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleAscendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksTitleAscendingSorting.Books.First().Id,
                booksTitleAscendingSorting.Books.Skip(1).First().Id,
                booksTitleAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksTitleAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksTitleAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 2, 5, 4 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByTitleDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleDescendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksTitleDescendingSorting.Books.First().Id,
                booksTitleDescendingSorting.Books.Skip(1).First().Id,
                booksTitleDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksTitleDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksTitleDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 5, 2 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByAuthorAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorAscendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksAuthorAscendingSorting.Books.First().Id,
                booksAuthorAscendingSorting.Books.Skip(1).First().Id,
                booksAuthorAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksAuthorAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksAuthorAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 2 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByAuthorDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorDescendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksAuthorDescendingSorting.Books.First().Id,
                booksAuthorDescendingSorting.Books.Skip(1).First().Id,
                booksAuthorDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksAuthorDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksAuthorDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 2, 4, 5 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByPriceAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceAscendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksPriceAscendingSorting.Books.First().Id,
                booksPriceAscendingSorting.Books.Skip(1).First().Id,
                booksPriceAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksPriceAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksPriceAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 2, 4 }));
        }

        [Test]
        public async Task Test_AllCurrentlyReadingBooksIdsByUserIdAsync_SortsByPriceDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };
            var bookUserWantToReadThree = new BookUserCurrentlyReading()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };
            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceDescendingSorting = await service.AllCurrentlyReadingBooksIdsByUserIdAsync("testUser", null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksPriceDescendingSorting.Books.First().Id,
                booksPriceDescendingSorting.Books.Skip(1).First().Id,
                booksPriceDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksPriceDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksPriceDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 2, 5 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_FiltersByGenre()
        {
            // Act
            var result = await service.AllReadBooksIdsByUserIdAsync("testUser", "History");
            var resultTwo = await service.AllReadBooksIdsByUserIdAsync("testUser", "NotAnExistingBook");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 2, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllReadBooksIdsByUserIdAsync("testUser", null, "The History");
            var resultTwo = await service.AllReadBooksIdsByUserIdAsync("testUser", null, "NotAValidSearchTerm");

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 3, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByNewest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksNewestSorting = await service.AllReadBooksIdsByUserIdAsync("testUser");
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 3 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByOldest()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksOldestSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.Oldest);
            var booksIds = new List<int>()
            {
                booksOldestSorting.Books.First().Id,
                booksOldestSorting.Books.Skip(1).First().Id,
                booksOldestSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksOldestSorting.Books, Is.Not.Null);
            Assert.That(booksOldestSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 3, 4, 5 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByTitleAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleAscendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.TitleAscending);
            var booksIds = new List<int>()
            {
                booksTitleAscendingSorting.Books.First().Id,
                booksTitleAscendingSorting.Books.Skip(1).First().Id,
                booksTitleAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksTitleAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksTitleAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 3 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByTitleDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksTitleDescendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.TitleDescending);
            var booksIds = new List<int>()
            {
                booksTitleDescendingSorting.Books.First().Id,
                booksTitleDescendingSorting.Books.Skip(1).First().Id,
                booksTitleDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksTitleDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksTitleDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 3, 4, 5 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByAuthorAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorAscendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.AuthorAscending);
            var booksIds = new List<int>()
            {
                booksAuthorAscendingSorting.Books.First().Id,
                booksAuthorAscendingSorting.Books.Skip(1).First().Id,
                booksAuthorAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksAuthorAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksAuthorAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 3, 5, 4 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByAuthorDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksAuthorDescendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.AuthorDescending);
            var booksIds = new List<int>()
            {
                booksAuthorDescendingSorting.Books.First().Id,
                booksAuthorDescendingSorting.Books.Skip(1).First().Id,
                booksAuthorDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksAuthorDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksAuthorDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 5, 3 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByPriceAscending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceAscendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.PriceAscending);
            var booksIds = new List<int>()
            {
                booksPriceAscendingSorting.Books.First().Id,
                booksPriceAscendingSorting.Books.Skip(1).First().Id,
                booksPriceAscendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksPriceAscendingSorting.Books, Is.Not.Null);
            Assert.That(booksPriceAscendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 3, 4 }));
        }

        [Test]
        public async Task Test_AllReadBooksIdsByUserIdAsync_SortsByPriceDescending()
        {
            //Arrange 
            var bookUserWantToReadTwo = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 4,
                TimeAdded = DateTime.Now
            };

            var bookUserWantToReadThree = new BookUserRead()
            {
                UserId = "testUser",
                BookId = 5,
                TimeAdded = DateTime.Now
            };

            dbContext.AddAsync(bookUserWantToReadTwo);
            dbContext.AddAsync(bookUserWantToReadThree);
            dbContext.SaveChanges();

            // Act
            var booksPriceDescendingSorting = await service.AllReadBooksIdsByUserIdAsync("testUser", null, null, BookSorting.PriceDescending);
            var booksIds = new List<int>()
            {
                booksPriceDescendingSorting.Books.First().Id,
                booksPriceDescendingSorting.Books.Skip(1).First().Id,
                booksPriceDescendingSorting.Books.Skip(2).First().Id,
            };

            // Assert
            Assert.That(booksPriceDescendingSorting.Books, Is.Not.Null);
            Assert.That(booksPriceDescendingSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 4, 3, 5 }));
        }

        [Test]
        public async Task Test_BookIsInAnotherCollectionAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultWantToRead = await service.BookIsInAnotherCollectionAsync(1, "testUser");
            var resultCurrentlyReading = await service.BookIsInAnotherCollectionAsync(2, "testUser");
            var resultRead = await service.BookIsInAnotherCollectionAsync(3, "testUser");
            var resultNotInCollection = await service.BookIsInAnotherCollectionAsync(4, "testUser");

            // Assert
            Assert.That(resultWantToRead, Is.True);
            Assert.That(resultCurrentlyReading, Is.True);
            Assert.That(resultRead, Is.True);
            Assert.That(resultNotInCollection, Is.False);
        }

        [Test]
        public async Task Test_RemoveBookFromAllCollectionsAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultWantToRead = service.RemoveBookFromAllCollectionsAsync(1, "testUser").Result;
            var resultCurrentlyReading = service.RemoveBookFromAllCollectionsAsync(2, "testUser").Result;
            var resultRead = service.RemoveBookFromAllCollectionsAsync(3, "testUser").Result;

            // Assert
            Assert.That(resultWantToRead, Is.EqualTo(1));
            Assert.That(resultCurrentlyReading, Is.EqualTo(1));
            Assert.That(resultRead, Is.EqualTo(1));
        }

        [Test]
        public async Task Test_BookIsWantToReadAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultWantToRead = await service.BookIsWantToReadAsync(1, "testUser");
            var resultNotWantToRead = await service.BookIsWantToReadAsync(2, "testUser");

            // Assert
            Assert.That(resultWantToRead, Is.True);
            Assert.That(resultNotWantToRead, Is.False);
        }

        [Test]
        public async Task Test_BookIsCurrentlyReadingAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultCurrentlyReading = await service.BookIsCurrentlyReadingAsync(2, "testUser");
            var resultNotCurrentlyReading = await service.BookIsCurrentlyReadingAsync(1, "testUser");

            // Assert
            Assert.That(resultCurrentlyReading, Is.True);
            Assert.That(resultNotCurrentlyReading, Is.False);
        }

        [Test]
        public async Task Test_BookIsReadAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultRead = await service.BookIsReadAsync(3, "testUser");
            var resultNotRead = await service.BookIsReadAsync(1, "testUser");

            // Assert
            Assert.That(resultRead, Is.True);
            Assert.That(resultNotRead, Is.False);
        }

        [Test]
        public async Task Test_AddWantToReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testSecondUser";

            // Act
            var result = await service.AddWantToReadBookAsync(1, userId);
            var expectedResult = await service.BookIsWantToReadAsync(1, userId);

            // Assert
            Assert.That(result, Is.EqualTo(1));
            Assert.That(expectedResult, Is.True);
        }

        [Test]
        public async Task Test_AddCurrentlyReadingBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testSecondUser";

            // Act
            var result = await service.AddCurrentlyReadingBookAsync(2, userId);
            var expectedResult = await service.BookIsCurrentlyReadingAsync(2, userId);
            var book = await service.FindBookCurrentlyReadingAsync(2, userId);

            // Assert
            Assert.That(result, Is.EqualTo(2));
            Assert.That(expectedResult, Is.True);
            Assert.That(book.CurrentPage, Is.EqualTo(1));
        }

        [Test]
        public async Task Test_AddReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testSecondUser";

            // Act
            var result = await service.AddReadBookAsync(3, userId);
            var expectedResult = await service.BookIsReadAsync(3, userId);

            // Assert
            Assert.That(result, Is.EqualTo(3));
            Assert.That(expectedResult, Is.True);
        }

        [Test]
        public async Task Test_RemoveWantToReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testUser";

            // Act
            var result = await service.RemoveWantToReadBookAsync(1, userId);
            var expectedResult = await service.BookIsWantToReadAsync(1, userId);

            // Assert
            Assert.That(result, Is.EqualTo(1));
            Assert.That(expectedResult, Is.False);
        }

        [Test]
        public async Task Test_RemoveCurrentlyReadingBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testUser";

            // Act
            var result = await service.RemoveCurrentlyReadingBookAsync(2, userId);
            var expectedResult = await service.BookIsCurrentlyReadingAsync(2, userId);

            // Assert
            Assert.That(result, Is.EqualTo(2));
            Assert.That(expectedResult, Is.False);
        }

        [Test]
        public async Task Test_RemoveReadBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            string userId = "testUser";

            // Act
            var result = await service.RemoveReadBookAsync(3, userId);
            var expectedResult = await service.BookIsReadAsync(3, userId);

            // Assert
            Assert.That(result, Is.EqualTo(3));
            Assert.That(expectedResult, Is.False);
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await service.AllBookReviewsAsync(TheCallOfTheWild.Id, TheCallOfTheWild.Title, "Review Title");
            var resultTwo = await service.AllBookReviewsAsync(TheCallOfTheWild.Id, TheCallOfTheWild.Title, "Not a valid search");

            // Assert
            Assert.That(result.TotalReviewsCount, Is.EqualTo(1));
            Assert.That(result.BookReviews.First().Id == 1, Is.True);

            Assert.That(resultTwo.TotalReviewsCount, Is.EqualTo(0));
            Assert.That(resultTwo.BookReviews, Is.Empty);
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByNewest()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 10
            };

            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 10
            };

            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsNewestSorting = await service.AllBookReviewsAsync(TheCallOfTheWild.Id, TheCallOfTheWild.Title);
            var booksIds = new List<int>()
            {
                bookReviewsNewestSorting.BookReviews.First().Id,
                bookReviewsNewestSorting.BookReviews.Skip(1).First().Id,
                bookReviewsNewestSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.That(bookReviewsNewestSorting.BookReviews, Is.Not.Null);
            Assert.That(bookReviewsNewestSorting.BookReviews.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 3, 2, 1 }));
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByOldest()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 10
            };

            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 10
            };

            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsOldestSorting = await service.AllBookReviewsAsync(TheCallOfTheWild.Id, TheCallOfTheWild.Title, null, BookReviewSorting.Oldest);
            var booksIds = new List<int>()
            {
                bookReviewsOldestSorting.BookReviews.First().Id,
                bookReviewsOldestSorting.BookReviews.Skip(1).First().Id,
                bookReviewsOldestSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.That(bookReviewsOldestSorting.BookReviews, Is.Not.Null);
            Assert.That(bookReviewsOldestSorting.BookReviews.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByRateAscending()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 9
            };

            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 8
            };

            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsRateAscendingSorting = await service.AllBookReviewsAsync(TheCallOfTheWild.Id, TheCallOfTheWild.Title, null, BookReviewSorting.RateAscending);
            var booksIds = new List<int>()
            {
                bookReviewsRateAscendingSorting.BookReviews.First().Id,
                bookReviewsRateAscendingSorting.BookReviews.Skip(1).First().Id,
                bookReviewsRateAscendingSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.That(bookReviewsRateAscendingSorting.BookReviews, Is.Not.Null);
            Assert.That(bookReviewsRateAscendingSorting.BookReviews.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 3, 2, 1 }));
        }

        [Test]
        public async Task Test_AllBookReviewsAsync_SortsByRateDescending()
        {
            //Arrange 
            var bookReviewTwo = new BookReview()
            {
                Id = 2,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Two",
                Description = "Review Description Two",
                Rate = 9
            };

            var bookReviewThree = new BookReview()
            {
                Id = 3,
                UserId = "testUser",
                BookId = 1,
                Title = "Review Title Three",
                Description = "Review Description Three",
                Rate = 8
            };

            dbContext.AddAsync(bookReviewTwo);
            dbContext.AddAsync(bookReviewThree);
            dbContext.SaveChanges();

            // Act
            var bookReviewsRateDescendingSorting = await service.AllBookReviewsAsync(TheCallOfTheWild.Id, TheCallOfTheWild.Title, null, BookReviewSorting.RateDescending);
            var booksIds = new List<int>()
            {
                bookReviewsRateDescendingSorting.BookReviews.First().Id,
                bookReviewsRateDescendingSorting.BookReviews.Skip(1).First().Id,
                bookReviewsRateDescendingSorting.BookReviews.Skip(2).First().Id,
            };

            // Assert
            Assert.That(bookReviewsRateDescendingSorting.BookReviews, Is.Not.Null);
            Assert.That(bookReviewsRateDescendingSorting.BookReviews.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }

        [Test]
        public async Task Test_AddBookReviewAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new BookReviewAddViewModel()
            {
                UserId = "testUser",
                BookId = 2,
                Title = "Review Title",
                Description = "Review Description",
                Rate = 10
            };

            // Act
            var result = await service.AddBookReviewAsync(addForm, "testUser", 2);
            var expectedResult = await service.FindBookReviewByIdAsync(result);

            // Assert
            Assert.That(result, Is.EqualTo(2));
            Assert.That(expectedResult, Is.Not.Null);
        }

        [Test]
        public async Task Test_FindBookReviewAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExistingReview = await service.FindBookReviewByIdAsync(1);

            // Assert
            Assert.That(resultExistingReview, Is.Not.Null);
            Assert.That(resultExistingReview.Id, Is.EqualTo(bookReview.Id));
        }

        [Test]
        public async Task Test_DeleteBookReviewAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var deleteModel = new BookReviewDeleteViewModel()
            {
                ReviewId = bookReview.Id,
                BookId = bookReview.BookId,
                BookTitle = TheCallOfTheWild.Title
            };

            // Act
            var result = await service.DeleteBookReviewAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReviewId, Is.EqualTo(deleteModel.ReviewId));
            Assert.That(result.BookId, Is.EqualTo(deleteModel.BookId));
            Assert.That(result.BookTitle, Is.EqualTo(deleteModel.BookTitle));
        }

        [Test]
        public async Task Test_DeleteBookReviewConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await service.DeleteBookReviewConfirmedAsync(1);

            // Assert
            Assert.That(result, Is.EqualTo(1));
            Assert.That(await service.FindBookReviewByIdAsync(1), Is.Null);
        }

        [Test]
        public async Task Test_BookReviewDetailsAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewDetails = new BookReviewDetailsViewModel()
            {
                Id = bookReview.Id,
                BookId = bookReview.BookId,
                Title = bookReview.Title,
                Description = bookReview.Description,
                Rate = bookReview.Rate,
                AuthorId = bookReview.UserId
            };

            // Act
            var result = await service.BookReviewDetailsAsync(1);

            // Assert
            Assert.That(result.Id, Is.EqualTo(bookReviewDetails.Id));
            Assert.That(result.BookId, Is.EqualTo(bookReviewDetails.BookId));
            Assert.That(result.Title, Is.EqualTo(bookReviewDetails.Title));
            Assert.That(result.Description, Is.EqualTo(bookReviewDetails.Description));
            Assert.That(result.Rate, Is.EqualTo(bookReviewDetails.Rate));
            Assert.That(result.AuthorId, Is.EqualTo(bookReviewDetails.AuthorId));
        }

        [Test]
        public async Task Test_EditBookReviewGetAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewDetails = new BookReviewEditViewModel()
            {
                Id = bookReview.Id,
                BookId = bookReview.BookId,
                Title = bookReview.Title,
                Description = bookReview.Description,
                Rate = bookReview.Rate,
                UserId = bookReview.UserId
            };

            // Act
            var result = await service.EditBookReviewGetAsync(1);

            // Assert
            Assert.That(result.Id, Is.EqualTo(bookReviewDetails.Id));
            Assert.That(result.BookId, Is.EqualTo(bookReviewDetails.BookId));
            Assert.That(result.Title, Is.EqualTo(bookReviewDetails.Title));
            Assert.That(result.Description, Is.EqualTo(bookReviewDetails.Description));
            Assert.That(result.Rate, Is.EqualTo(bookReviewDetails.Rate));
            Assert.That(result.UserId, Is.EqualTo(bookReviewDetails.UserId));
        }

        [Test]
        public async Task Test_EditBookReviewPostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewDetails = new BookReviewEditViewModel()
            {
                Id = bookReview.Id,
                BookId = bookReview.BookId,
                Title = bookReview.Title + " Changed",
                Description = bookReview.Description + " Changed",
                Rate = bookReview.Rate - 1,
                UserId = bookReview.UserId
            };

            // Act
            var result = await service.EditBookReviewPostAsync(bookReviewDetails);
            var editedReview = await service.FindBookReviewByIdAsync(bookReview.Id);

            // Assert
            Assert.That(result, Is.EqualTo(bookReview.Id));

            Assert.That(editedReview.Id, Is.EqualTo(bookReviewDetails.Id));
            Assert.That(editedReview.BookId, Is.EqualTo(bookReviewDetails.BookId));
            Assert.That(editedReview.Title, Is.EqualTo(bookReviewDetails.Title));
            Assert.That(editedReview.Description, Is.EqualTo(bookReviewDetails.Description));
            Assert.That(editedReview.Rate, Is.EqualTo(bookReviewDetails.Rate));
            Assert.That(editedReview.UserId, Is.EqualTo(bookReviewDetails.UserId));
        }

        [Test]
        public async Task Test_BookReviewQuestionAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var bookReviewQuestion = new BookReviewQuestionViewModel()
            {
                Title = AroundTheWorldOf80Days.Title,
                Id = AroundTheWorldOf80Days.Id
            };

            // Act
            var result = await service.BookReviewQuestionAsync(3);

            // Assert
            Assert.That(result.Title, Is.EqualTo(bookReviewQuestion.Title));
            Assert.That(result.Id, Is.EqualTo(bookReviewQuestion.Id));
        }

        [Test]
        public async Task Test_ChangePageGetAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var changePageForm = new ChangePageViewModel()
            {
                BookId = TheHistoryOfHeridot.Id,
                UserId = "testUser",
                BookPages = TheHistoryOfHeridot.Pages,
                CurrentPage = 0
            };

            // Act
            var result = await service.ChangePageGetAsync(TheHistoryOfHeridot.Id, "testUser");

            // Assert
            Assert.That(result.BookId, Is.EqualTo(changePageForm.BookId));
            Assert.That(result.UserId, Is.EqualTo(changePageForm.UserId));
            Assert.That(result.BookPages, Is.EqualTo(changePageForm.BookPages));
            Assert.That(result.CurrentPage, Is.EqualTo(changePageForm.CurrentPage));
        }

        [Test]
        public async Task Test_ChangePagePostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var changePageForm = new ChangePageViewModel()
            {
                BookId = TheHistoryOfHeridot.Id,
                UserId = "testUser",
                BookPages = TheHistoryOfHeridot.Pages,
                CurrentPage = 30
            };

            // Act
            var result = await service.ChangePagePostAsync(changePageForm);
            var book = await service.FindBookCurrentlyReadingAsync(TheHistoryOfHeridot.Id, "testUser");

            // Assert
            Assert.That(result, Is.EqualTo(changePageForm.BookId));
            Assert.That(changePageForm.CurrentPage, Is.EqualTo(book.CurrentPage));
        }

        [Test]
        public async Task Test_FindBookCurrentlyReadingAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            int currentlyReadingBookId = 2;
            int nonExistingCurrentlyReadingBookId = -2;

            // Act
            var resultOne = await service.FindBookCurrentlyReadingAsync(currentlyReadingBookId, "testUser");
            var resultTwo = await service.FindBookCurrentlyReadingAsync(nonExistingCurrentlyReadingBookId, "testUser");

            // Assert
            Assert.That(resultOne, Is.Not.Null);
            Assert.That(resultOne.BookId, Is.EqualTo(currentlyReadingBookId));
            Assert.That(resultOne.UserId, Is.EqualTo("testUser"));

            Assert.That(resultTwo, Is.Null);
        }
    }
}