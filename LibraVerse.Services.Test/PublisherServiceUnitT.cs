namespace LibraVerse.Services.Test
{
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Services;

    using LibraVerse.Data;
    using LibraVerse.Data.Repository;

    using LibraVerse.Data.Models.Articles;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.BookStores;
    using LibraVerse.Data.Models.BookUserActions;
    using LibraVerse.Data.Models.Events;
    using LibraVerse.Data.Models.Mappings;
    using LibraVerse.Data.Models.Roles;
    using LibraVerse.Core.Models.ViewModels.Book;
    using LibraVerse.Core.Models.ViewModels.Article;

    using LibraVerse.Core.Enums;

    using LibraVerse.Core.Models.ViewModels.BookStore;
    using LibraVerse.Core.Models.ViewModels.Event;

    using static LibraVerse.Common.Constants.EntityValidationConstants.Article;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookStore;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Event;
    [TestFixture]
    public class PublisherServiceUnitT
    {
        //The DB & Services
        private LibraDbContext dbContext;

        //Collections
        private IRepository repository;
        private IPublisherService publisherService;
        private IBookService bookService;
        private IBookStoreService bookStoreService;
        private IEventService eventService;
        private IArticleService articleService;

        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Book> books;
        private IEnumerable<Genre> genres;

        //Books
        private Book Book1;
        private Book Book2;
        private Book Book3;
        private Book Book4;
        private Book Book5;
        private Book Book6;
        private Book Book7;
        private Book Book8;
        private Book Book9;
        private Book Book10;

        private BookStore bookStore;
        private BookReview bookReview;
        private BookBookStore bookBookStore;
        private BookUserWantToRead bookUserWantToRead;
        private BookUserCurrentlyReading bookUserCurrentlyReading;
        private BookUserRead bookUserRead;

        //Genres
        private Genre Adventure;
        private Genre History;
        private Genre Historiography;
        private Genre Art;
        private Genre Children;
        private Genre Drama;
        private Genre Science;
        private Genre ClassicLiterature;

        //Articles
        private Article article;

        //Events
        private Event testEvent;
        private EventParticipant eventParticipant;

        //Users and Publishers
        private ApplicationUser userOne;
        private ApplicationUser userTwo;
        private Publisher publisher;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            //Books
            Book1 = new Book()
            {
                Id = 1,
                Title = "The Call of The Wild",
                Author = "Jack London",
                Genre = Adventure,
                GenreId = 1,
                Description = "The description of The Call of the Wild book",
                Pages = 128,
                YearPublished = 1903,
                Price = 5.00m,
                ImageUrl = "https://i2.helikon.bg/products/4956/05/54956/0658229_b.jpg?t=1732090822",
            };

            Book2 = new Book()
            {
                Id = 2,
                Title = "A Slavonic-bulgarian history",
                Author = "Paisii Hilendarski",
                Genre = Historiography,
                GenreId = 3,
                Description = "The history of bulgarians",
                Pages = 240,
                YearPublished = 1762,
                Price = 30.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/i/s/istoria-slavianobylgarska.jpg",
            };

            Book3 = new Book()
            {
                Id = 3,
                Title = "The history of Heridot",
                Author = "Heridot",
                Genre = History,
                GenreId = 2,
                Description = "The description of this book",
                Pages = 810,
                YearPublished = 1888,
                Price = 50.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/h/e/herodot-istoria.jpg",
            };

            Book4 = new Book()
            {
                Id = 4,
                Title = "The history of an Art",
                Author = "Nikolay Raynov",
                Genre = Art,
                GenreId = 4,
                Description = "The description of The history of an Art book",
                Pages = 808,
                YearPublished = 2024,
                Price = 98.00m,
                ImageUrl = "https://i2.helikon.bg/products/6357/24/246357/246357_b.jpg?t=1732093233",
            };

            bookStore = new BookStore()
            {
                Id = 1,
                Name = "Test Name",
                Location = "Test Location",
                ImageUrl = "",
                OpeningTime = DateTime.ParseExact("08:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("20:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 88 651 1944",
            };

            bookReview = new BookReview()
            {
                Id = 1,
                BookId = 1,
                Title = "Test Title",
                Description = "Test Description",
                UserId = "TestItOne",
                Rate = 10
            };

            bookBookStore = new BookBookStore()
            {
                BookId = 1,
                BookStoreId = 1
            };

            bookUserWantToRead = new BookUserWantToRead()
            {
                BookId = 1,
                UserId = "TestItOne"
            };

            bookUserCurrentlyReading = new BookUserCurrentlyReading()
            {
                BookId = 1,
                UserId = "TestItOne"
            };

            bookUserRead = new BookUserRead()
            {
                BookId = 1,
                UserId = "TestItOne"
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
                Name = "History"
            };

            Historiography = new Genre()
            {
                Id = 3,
                Name = "Historiography"
            };

            Art = new Genre()
            {
                Id = 4,
                Name = "Art"
            };

            //Articles
            article = new Article()
            {
                Id = 1,
                Title = "Test Title",
                Content = "Test Content",
                ImageUrl = "Test URL",
                DatePublished = DateTime.ParseExact("05/01/2025 18:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            //Events
            testEvent = new Event()
            {
                Id = 1,
                Topic = "Test Topic",
                Description = "Test Description",
                Location = "Test Location",
                StartDate = DateTime.ParseExact("10/10/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("10/10/2024 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "Test URL",
                Seats = 100,
                TicketPrice = 12
            };

            eventParticipant = new EventParticipant()
            {
                ParticipantId = "TestItOne",
                EventId = 1
            };

            //The Users & the Publisher
            userOne = new ApplicationUser()
            {
                Id = "TestItOne",
                UserName = "yonni@gmail.com",
                NormalizedUserName = "YONNI@GMAIL.COM",
                Email = "yonni@gmail.com",
                NormalizedEmail = "YONNI@GMAIL.COM",
                FirstName = "Yonni",
                LastName = "Bonboni"
            };

            userTwo = new ApplicationUser()
            {
                Id = "TestItTwo",
                UserName = "ivankl@gmail.com",
                NormalizedUserName = "IVANKL@GMAIL.COM",
                Email = "ivankl@gmail.com",
                NormalizedEmail = "IVANKL@GMAIL.COM",
                FirstName = "Ivan",
                LastName = "Best"
            };

            publisher = new Publisher()
            {
                Id = 1,
                UserId = userOne.Id
            };

            //Collections
            users = new List<ApplicationUser>()
            {
                userOne, userTwo
            };

            books = new List<Book>()
            {
                Book1, Book2, Book3, Book4
            };

            genres = new List<Genre>()
            {
                Adventure, Historiography, Historiography, Art
            };

            //In-Memory DB
            var options = new DbContextOptionsBuilder<LibraDbContext>()
                .UseInMemoryDatabase(databaseName: "LibraVerseInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new LibraDbContext(options);
            SeedDatabase();

            //Services
            repository = new Repository(dbContext);
            bookService = new BookService(repository);
            bookStoreService = new BookStoreService(repository);
            eventService = new EventService(repository);
            articleService = new ArticleService(repository);
            publisherService = new PublisherService(repository, bookService);
        }

        private async Task SeedDatabase()
        {
            dbContext.AddRangeAsync(books);
            dbContext.AddRangeAsync(genres);

            dbContext.AddAsync(bookStore);
            dbContext.AddAsync(bookReview);
            dbContext.AddAsync(bookBookStore);
            dbContext.AddAsync(bookUserWantToRead);
            dbContext.AddAsync(bookUserCurrentlyReading);
            dbContext.AddAsync(bookUserRead);

            dbContext.AddRangeAsync(users);
            dbContext.AddAsync(publisher);
            dbContext.AddAsync(article);
            dbContext.AddAsync(testEvent);
            dbContext.AddAsync(eventParticipant);
            dbContext.SaveChangesAsync();
        }
        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task Test_ExistsByPublisherIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.ExistsByPublisherIdAsync(1);
            var resultTwo = await publisherService.ExistsByPublisherIdAsync(2);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(resultTwo, Is.False);
        }

        [Test]
        public async Task Test_ExistsByUserIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.ExistsByUserIdAsync("TestItOne");
            var resultTwo = await publisherService.ExistsByUserIdAsync("TestItTwo");

            // Assert
            Assert.That(result, Is.True);
            Assert.That(resultTwo, Is.False);
        }

        [Test]
        public async Task Test_ExistsByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.ExistsByEmailAsync("yonni@gmail.com");
            var resultTwo = await publisherService.ExistsByEmailAsync("ivankl@gmail.com");

            // Assert
            Assert.That(result, Is.True);
            Assert.That(resultTwo, Is.False);
        }

        [Test]
        public async Task Test_GetPublisherByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.GetPublisherByEmailAsync("yonni@gmail.com");

            // Assert
            Assert.That(publisher, Is.EqualTo(result));
        }

        [Test]
        public async Task Test_GetPublisherIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.GetPublisherIdAsync("TestItOne");

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        //Books
        [Test]
        public async Task Test_AddBookAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new BookAddViewModel()
            {
                Title = "A Slavonic-bulgarian history",
                Author = "Paisii Hilendarski",
                GenreId = 3,
                Description = "The history of bulgarians",
                Pages = 240,
                YearPublished = 1762,
                Price = 30.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/i/s/istoria-slavianobylgarska.jpg",
            };

            // Act
            await publisherService.AddBookAsync(addForm);
            var currentBook = await bookService.FindBookByIdAsync(2);

            //Assert
            Assert.That(currentBook.Title, Is.EqualTo ("A Slavonic-bulgarian history"));
            Assert.That(currentBook.Author, Is.EqualTo("Paisii Hilendarski"));
            Assert.That(currentBook.GenreId, Is.EqualTo(3));
            Assert.That(currentBook.Description, Is.EqualTo("The history of bulgarians"));
            Assert.That(currentBook.Pages, Is.EqualTo(240));
            Assert.That(currentBook.YearPublished, Is.EqualTo(1762));
            Assert.That(currentBook.Price, Is.EqualTo(30.00m));
            Assert.That(currentBook.ImageUrl, Is.EqualTo("https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/i/s/istoria-slavianobylgarska.jpg"));

            await publisherService.DeleteBookConfirmedAsync(currentBook.Id);
        }

        [Test]
        public async Task Test_EditBookGetAsync_ReturnsTheCorrectResult()
        {
            //Arrange
            var form = new BookEditViewModel()
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

            //Act
            var result = await publisherService.EditBookGetAsync(1);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Title, Is.EqualTo("The Call of The Wild"));
            Assert.That(result.Author, Is.EqualTo("Jack London"));
            Assert.That(result.GenreId, Is.EqualTo(1));
            Assert.That(result.Description, Is.EqualTo("The description of The Call of the Wild book"));
            Assert.That(result.Pages, Is.EqualTo(128));
            Assert.That(result.YearPublished, Is.EqualTo(1903));
            Assert.That(result.Price, Is.EqualTo(5.00m));
            Assert.That(result.ImageUrl, Is.EqualTo("https://i2.helikon.bg/products/4956/05/54956/0658229_b.jpg?t=1732090822"));
        }

        [Test]
        public async Task Test_EditBookPostAsync_ReturnsTheCorrectResult()
        {
            //Arrange
            var form = new BookEditViewModel()
            {
                Id = 1,
                Title = "The Call of The Wild Edited",
                Author = "Jack London Edited",
                GenreId = 1,
                Description = "The description of The Call of The Wild book Edited",
                Pages = 128,
                YearPublished = 1903,
                Price = 5.00m,
                ImageUrl = "https://i2.helikon.bg/products/4956/05/54956/0658229_b.jpg?t=1732090822"
            };

            //Act
            var result = await publisherService.EditBookPostAsync(form);
            var currentBook = await bookService.FindBookByIdAsync(result);

            //Assert
            Assert.That(currentBook.Title, Is.EqualTo("The Call of The Wild Edited"));
            Assert.That(currentBook.Author, Is.EqualTo("Jack London Edited"));
            Assert.That(currentBook.GenreId, Is.EqualTo(1));
            Assert.That(currentBook.Description, Is.EqualTo("The description of The Call of The Wild book Edited"));
            Assert.That(currentBook.Pages, Is.EqualTo(128));
            Assert.That(currentBook.YearPublished, Is.EqualTo(1903));
            Assert.That(currentBook.Price, Is.EqualTo(5.00m));
            Assert.That(currentBook.ImageUrl, Is.EqualTo("https://i2.helikon.bg/products/4956/05/54956/0658229_b.jpg?t=1732090822"));
        }

        [Test]
        public async Task Test_DeleteBookAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.DeleteBookAsync(1);

            // Assert
            Assert.That(result.Id, Is.EqualTo(Book1.Id));
            Assert.That(result.Title, Is.EqualTo(Book1.Title));
            Assert.That(result.Author, Is.EqualTo(Book1.Author));
            Assert.That(result.ImageUrl, Is.EqualTo(Book1.ImageUrl));
        }

        [Test]
        public async Task Test_DeleteBookConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await publisherService.DeleteBookConfirmedAsync(1);

            // Assert
            Assert.That(dbContext.BooksBookStores.Count(), Is.EqualTo(0));
            Assert.That(dbContext.BookReviews.Count(), Is.EqualTo(0));
            Assert.That(dbContext.BooksUsersWantToRead.Count(), Is.EqualTo(0));
            Assert.That(dbContext.BooksUsersCurrentlyReading.Count(), Is.EqualTo(0));
            Assert.That(dbContext.BooksUsersRead.Count(), Is.EqualTo(0));
            Assert.That(dbContext.Books.Count(), Is.EqualTo(10));
            Assert.That(result, Is.EqualTo(1));
        }

        //Articles
        [Test]
        public async Task Test_AddArticleAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new ArticleAddViewModel()
            {
                Title = "Test Title",
                Content = "Test Content",
                ImageUrl = "Test URL"
            };

            // Act
            var result = publisherService.AddArticleAsync(addForm).Result;
            var article = articleService.FindArticleByIdAsync(result).Result;

            // Assert
            Assert.That(result, Is.EqualTo(2));
            Assert.That(article.Title, Is.EqualTo("Test Title"));
            Assert.That(article.Content, Is.EqualTo("Test Content"));
            Assert.That(article.ImageUrl, Is.EqualTo("Test URL"));
            Assert.That(article.DatePublished.Year, Is.EqualTo(DateTime.Now.Year));
            Assert.That(article.DatePublished.Month, Is.EqualTo(DateTime.Now.Month));
            Assert.That(article.DatePublished.Date, Is.EqualTo(DateTime.Now.Date));
            Assert.That(article.DatePublished.Hour, Is.EqualTo(DateTime.Now.Hour));
            Assert.That(article.DatePublished.Minute, Is.EqualTo(DateTime.Now.Minute));
            Assert.That(article.ViewsCount, Is.EqualTo(0));
        }

        [Test]
        public async Task Test_EditArticleGetAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.EditArticleGetAsync(1).Result;

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Title, Is.EqualTo("Test Title"));
            Assert.That(result.Content, Is.EqualTo("Test Content"));
            Assert.That(result.ImageUrl, Is.EqualTo("Test URL"));
        }

        [Test]
        public async Task Test_EditArticlePostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var editForm = new ArticleEditViewModel()
            {
                Id = 1,
                Title = "Test Title Edited",
                Content = "Test Content Edited",
                ImageUrl = "Test URL Edited"
            };

            // Act
            var result = publisherService.EditArticlePostAsync(editForm).Result;
            var article = articleService.FindArticleByIdAsync(result).Result;

            // Assert
            Assert.That(result, Is.EqualTo(1));
            Assert.That(article.Title, Is.EqualTo("Test Title Edited"));
            Assert.That(article.Content, Is.EqualTo("Test Content Edited"));
            Assert.That(article.ImageUrl, Is.EqualTo("Test URL Edited"));
        }

        [Test]
        public async Task Test_DeleteArticleAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteArticleAsync(1).Result;
            var article = articleService.FindArticleByIdAsync(result.Id).Result;

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(article.Title, Is.EqualTo("Test Title"));
            Assert.That(article.Content, Is.EqualTo("Test Content"));
            Assert.That(article.ImageUrl, Is.EqualTo("Test URL"));
        }

        [Test]
        public async Task Test_DeleteArticleConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteArticleConfirmedAsync(1).Result;

            // Assert
            Assert.That(dbContext.Articles.Count(), Is.EqualTo(0));
            Assert.That(dbContext.ArticleComments.Count(), Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(1));
        }

        //Events
        [Test]
        public async Task Test_AddEventAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new EventAddViewModel()
            {
                Topic = "Test Topic",
                Description = "Test Description",
                Location = "Test Location",
                StartDate = DateTime.ParseExact("10/10/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("10/10/2024 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "Test ImageUrl",
                Seats = 20,
                TicketPrice = 15.68m
            };

            // Act
            var result = publisherService.AddEventAsync(addForm).Result;
            var currentEvent = eventService.FindEventByIdAsync(result).Result;

            // Assert
            Assert.That(result, Is.EqualTo(2));
            Assert.That(dbContext.Events.Count(), Is.EqualTo(2));
            Assert.That(currentEvent.Topic, Is.EqualTo("Test Topic"));
            Assert.That(currentEvent.Description, Is.EqualTo("Test Description"));
            Assert.That(currentEvent.Location, Is.EqualTo("Test Location"));
            Assert.That(currentEvent.StartDate, Is.EqualTo(DateTime.ParseExact("10/10/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None)));
            Assert.That(currentEvent.EndDate, Is.EqualTo(DateTime.ParseExact("10/10/2024 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None)));
            Assert.That(currentEvent.ImageUrl, Is.EqualTo("Test ImageUrl"));
            Assert.That(currentEvent.Seats, Is.EqualTo(20));
            Assert.That(currentEvent.TicketPrice, Is.EqualTo(15.68m));
        }

        [Test]
        public async Task Test_EditEventGetAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.EditEventGetAsync(1).Result;

            // Assert
            Assert.That(result.Id, Is.EqualTo(testEvent.Id));
            Assert.That(result.Topic, Is.EqualTo(testEvent.Topic));
            Assert.That(result.Description, Is.EqualTo(testEvent.Description));
            Assert.That(result.Location, Is.EqualTo(testEvent.Location));
            Assert.That(result.StartDate, Is.EqualTo(testEvent.StartDate));
            Assert.That(result.EndDate, Is.EqualTo(testEvent.EndDate));
            Assert.That(result.ImageUrl, Is.EqualTo(testEvent.ImageUrl));
            Assert.That(result.Seats, Is.EqualTo(testEvent.Seats));
            Assert.That(result.TicketPrice, Is.EqualTo(testEvent.TicketPrice));
        }

        [Test]
        public async Task Test_EditEventPostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var editForm = new EventEditViewModel()
            {
                Id = 1,
                Topic = "Test Topic Edited",
                Description = "Test Description Edited",
                Location = "Test Location Edited",
                StartDate = DateTime.ParseExact("10/10/2025 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("10/10/2025 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "Test ImageUrl Edited",
                Seats = 30,
                TicketPrice = 20.68m
            };

            // Act
            var result = publisherService.EditEventPostAsync(editForm).Result;
            var editedEvent = eventService.FindEventByIdAsync(result).Result;

            // Assert
            Assert.That(editedEvent.Id, Is.EqualTo(editForm.Id));
            Assert.That(editedEvent.Topic, Is.EqualTo(editForm.Topic));
            Assert.That(editedEvent.Description, Is.EqualTo(editForm.Description));
            Assert.That(editedEvent.Location, Is.EqualTo(editForm.Location));
            Assert.That(editedEvent.StartDate, Is.EqualTo(editForm.StartDate));
            Assert.That(editedEvent.EndDate, Is.EqualTo(editForm.EndDate));
            Assert.That(editedEvent.ImageUrl, Is.EqualTo(editForm.ImageUrl));
            Assert.That(editedEvent.Seats, Is.EqualTo(editForm.Seats));
            Assert.That(editedEvent.TicketPrice, Is.EqualTo(editForm.TicketPrice));
        }

        [Test]
        public async Task Test_DeleteEventAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteEventAsync(1).Result;

            // Assert
            Assert.That(result.Id, Is.EqualTo(testEvent.Id));
            Assert.That(result.Topic, Is.EqualTo(testEvent.Topic));
            Assert.That(result.Location, Is.EqualTo(testEvent.Location));
            Assert.That(result.ImageUrl, Is.EqualTo(testEvent.ImageUrl));
        }

        [Test]
        public async Task Test_DeleteEventConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteEventConfirmedAsync(1).Result;

            // Assert
            Assert.That(dbContext.Events.Count(), Is.EqualTo(0));
            Assert.That(dbContext.EventsParticipants.Count(), Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(1));
        }


        //BookStores
        [Test]
        public async Task Test_AddBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var addForm = new BookStoreAddViewModel()
            {
                Name = "Test Name",
                Location = "Test Location",
                OpeningTime = new DateTime(this.bookStore.OpeningTime.Year, this.bookStore.OpeningTime.Month, this.bookStore.OpeningTime.Day, this.bookStore.OpeningTime.Hour, this.bookStore.OpeningTime.Minute, 0),
                ClosingTime = new DateTime(this.bookStore.ClosingTime.Year, this.bookStore.ClosingTime.Month, this.bookStore.ClosingTime.Day, this.bookStore.ClosingTime.Hour, this.bookStore.ClosingTime.Minute, 0),
                Contact = "Test Contact",
                ImageUrl = "Test ImageUrl"
            };

            // Act
            var result = publisherService.AddBookStoreAsync(addForm).Result;
            var bookStore = bookStoreService.FindBookStoreByIdAsync(result).Result;

            // Assert
            Assert.That(result, Is.EqualTo(2));
            Assert.That(dbContext.BookStores.Count(), Is.EqualTo(2));
            Assert.That(bookStore.Name, Is.EqualTo(addForm.Name));
            Assert.That(bookStore.Location, Is.EqualTo(addForm.Location));
            Assert.That(bookStore.OpeningTime.Hour, Is.EqualTo(addForm.OpeningTime.Hour));
            Assert.That(bookStore.OpeningTime.Minute, Is.EqualTo(addForm.OpeningTime.Minute));
            Assert.That(bookStore.ClosingTime.Hour, Is.EqualTo(addForm.ClosingTime.Hour));
            Assert.That(bookStore.ClosingTime.Minute, Is.EqualTo(addForm.ClosingTime.Minute));
            Assert.That(bookStore.Contact, Is.EqualTo(addForm.Contact));
            Assert.That(bookStore.ImageUrl, Is.EqualTo(addForm.ImageUrl));
        }

        [Test]
        public async Task Test_EditBookStoreGetAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.EditBookStoreGetAsync(1).Result;

            // Assert
            Assert.That(result.Id, Is.EqualTo(bookStore.Id));
            Assert.That(result.Name, Is.EqualTo(bookStore.Name));
            Assert.That(result.Location, Is.EqualTo(bookStore.Location));
            Assert.That(result.OpeningTime.Hour, Is.EqualTo(bookStore.OpeningTime.Hour));
            Assert.That(result.OpeningTime.Minute, Is.EqualTo(bookStore.OpeningTime.Minute));
            Assert.That(result.ClosingTime.Hour, Is.EqualTo(bookStore.ClosingTime.Hour));
            Assert.That(result.ClosingTime.Minute, Is.EqualTo(bookStore.ClosingTime.Minute));
            Assert.That(result.Contact, Is.EqualTo(bookStore.Contact));
            Assert.That(result.ImageUrl, Is.EqualTo(bookStore.ImageUrl));
        }

        [Test]
        public async Task Test_EditBookStorePostAsync_ReturnsTheCorrectResult()
        {
            // Arrange
            var editForm = new BookStoreEditViewModel()
            {
                Id = 1,
                Name = "Test Name Edited",
                Location = "Test Location Edited",
                OpeningTime = new DateTime(this.bookStore.OpeningTime.Year, this.bookStore.OpeningTime.Month, this.bookStore.OpeningTime.Day, this.bookStore.OpeningTime.Hour + 1, this.bookStore.OpeningTime.Minute + 1, 0),
                ClosingTime = new DateTime(this.bookStore.ClosingTime.Year, this.bookStore.ClosingTime.Month, this.bookStore.ClosingTime.Day, this.bookStore.ClosingTime.Hour + 1, this.bookStore.ClosingTime.Minute + 1, 0),
                Contact = "Test Contact Edited",
                ImageUrl = "Test ImageUrl Edited"
            };

            // Act
            var result = publisherService.EditBookStorePostAsync(editForm).Result;
            var editedBookStore = bookStoreService.FindBookStoreByIdAsync(result).Result;

            // Assert
            Assert.That(result, Is.EqualTo(1));
            Assert.That(editedBookStore.Name, Is.EqualTo(editForm.Name));
            Assert.That(editedBookStore.Location, Is.EqualTo(editForm.Location));
            Assert.That(editedBookStore.OpeningTime.Hour, Is.EqualTo(editForm.OpeningTime.Hour));
            Assert.That(editedBookStore.OpeningTime.Minute, Is.EqualTo(editForm.OpeningTime.Minute));
            Assert.That(editedBookStore.ClosingTime.Hour, Is.EqualTo(editForm.ClosingTime.Hour));
            Assert.That(editedBookStore.ClosingTime.Minute, Is.EqualTo(editForm.ClosingTime.Minute));
            Assert.That(editedBookStore.Contact, Is.EqualTo(editForm.Contact));
            Assert.That(editedBookStore.ImageUrl, Is.EqualTo(editForm.ImageUrl));
        }

        [Test]
        public async Task Test_DeleteBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteBookStoreAsync(1).Result;

            // Assert
            Assert.That(result.Name, Is.EqualTo(bookStore.Name));
            Assert.That(result.ImageUrl, Is.EqualTo(bookStore.ImageUrl));
        }

        [Test]
        public async Task Test_DeleteBookStoreConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.DeleteBookStoreConfirmedAsync(1).Result;

            // Assert
            Assert.That(dbContext.BookStores.Count(), Is.EqualTo(0));
            Assert.That(dbContext.BooksBookStores.Count(), Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task Test_BookExistsInBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultTrue = publisherService.BookExistsInBookStoreAsync(1, 1).Result;
            var resultFalse = publisherService.BookExistsInBookStoreAsync(2, 1).Result;

            // Assert
            Assert.That(resultTrue, Is.True);
            Assert.That(resultFalse, Is.False);
        }

        [Test]
        public async Task Test_AddBookToBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultOne = publisherService.AddBookToBookStoreAsync(1, 1).Result;
            var resultTwo = publisherService.AddBookToBookStoreAsync(2, 1).Result;

            // Assert
            Assert.That(dbContext.BooksBookStores.Count(), Is.EqualTo(2));
            Assert.That(bookBookStore, Is.EqualTo(resultOne));
            Assert.That(resultTwo.BookId, Is.EqualTo(2));
            Assert.That(resultTwo.BookStoreId, Is.EqualTo(1));
        }

        [Test]
        public async Task Test_RemoveBookFromBookStoreAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.RemoveBookFromBookStoreAsync(Book1.Id, bookStore.Id).Result;

            // Assert
            Assert.That(result.BookId, Is.EqualTo(Book1.Id));
            Assert.That(result.BookStoreId, Is.EqualTo(bookStore.Id));
            Assert.That(result.BookTitle, Is.EqualTo(Book1.Title));
            Assert.That(result.BookImageUrl, Is.EqualTo(Book1.ImageUrl));
            Assert.That(result.BookStoreName, Is.EqualTo(bookStore.Name));
        }

        [Test]
        public async Task Test_RemoveBookFromBookStoreConfirmedAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = publisherService.RemoveBookFromBookStoreConfirmedAsync(Book1.Id, bookStore.Id);

            // Assert
            Assert.That(dbContext.BooksBookStores.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_FiltersByGenre()
        {
            // Act
            var result = publisherService.AllBooksToChooseAsync(1, "Adventure").Result;
            var resultTwo = publisherService.AllBooksToChooseAsync(1, "History").Result;

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 1, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }


        [Test]
        public async Task Test_AllBooksToChooseAsync_FiltersBySearchTerm()
        {
            // Act
            var result = publisherService.AllBooksToChooseAsync(1, null, "The Call of The Wild").Result;
            var resultTwo = publisherService.AllBooksToChooseAsync(1, null, "NotAValidSearchTerm").Result;

            // Assert
            Assert.That(result.TotalBooksCount, Is.EqualTo(1));
            Assert.That(result.Books.First().Id == 1, Is.True);

            Assert.That(resultTwo.TotalBooksCount, Is.EqualTo(0));
            Assert.That(resultTwo.Books, Is.Empty);
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByNewest()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(5));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 3, 2 }));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByOldest()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, BookSorting.Oldest).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(4));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 2, 3, 4, 5 }));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByTitleAscending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, BookSorting.TitleAscending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(4));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 2, 4, 3, 5 }));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByTitleDescending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, BookSorting.TitleDescending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(4));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 3, 4, 2 }));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByAuthorAscending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, BookSorting.AuthorAscending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(3));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 4, 3, 2 }));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByAuthorDescending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, BookSorting.AuthorDescending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(4));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 2, 3, 4, 5 }));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByPriceAscending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, BookSorting.PriceAscending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(4));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 3, 4, 5, 2 }));
        }

        [Test]
        public async Task Test_AllBooksToChooseAsync_SortsByPriceDescending()
        {
            // Act
            var booksNewestSorting = publisherService.AllBooksToChooseAsync(1, null, null, BookSorting.PriceDescending).Result;
            var booksIds = new List<int>()
            {
                booksNewestSorting.Books.First().Id,
                booksNewestSorting.Books.Skip(1).First().Id,
                booksNewestSorting.Books.Skip(2).First().Id,
                booksNewestSorting.Books.Last().Id
            };

            // Assert
            Assert.That(booksNewestSorting.Books, Is.Not.Null);
            Assert.That(booksNewestSorting.Books.Count(), Is.EqualTo(4));
            Assert.That(booksIds, Is.EqualTo(new List<int>() { 5, 2, 4, 3 }));
        }
    }
}


