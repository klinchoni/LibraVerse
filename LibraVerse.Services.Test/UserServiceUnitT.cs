namespace LibraVerse.Services.Test
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    using LibraVerse.Data;
    using LibraVerse.Data.Repository;
    using LibraVerse.Data.Models.Roles;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Enums;
    using LibraVerse.Core.Services;



    [TestFixture]
    internal class UserServiceUnitT
    {
        //The DB & Services
        private LibraDbContext dbContext;

        private UserManager<ApplicationUser> userManager;
        private IRepository repository;
        private IPublisherService publisherService;
        private IUserService userService;
        private IBookService bookService;

        //The User
        private ApplicationUser userOne;
        private ApplicationUser userTwo;
        private ApplicationUser userThree;
        private ApplicationUser userFour;

        //The Role
        private Publisher publisher;

        // The Users list
        private List<ApplicationUser> users;

        [SetUp]
        public async Task Setup()
        {
            //The Users & Publishers
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

            userThree = new ApplicationUser()
            {
                Id = "TestItThree",
                UserName = "yordankaborisova@gmail.com",
                NormalizedUserName = "YORDANKABORISOVA@GMAIL.COM",
                Email = "yordankaborisova@gmail.com",
                NormalizedEmail = "YORDANKABORISOVA@GMAIL.COM",
                FirstName = "Yordanka",
                LastName = "Borisova"
            };

            userFour = new ApplicationUser()
            {
                Id = "TestItFour",
                UserName = "selena@gmail.com",
                NormalizedUserName = "SELENA@GMAIL.COM",
                Email = "selena@gmail.com",
                NormalizedEmail = "SELENA@GMAIL.COM",
                FirstName = "Selena",
                LastName = "Gomez"
            };

            publisher = new Publisher()
            {
                Id = 1,
                UserId = userTwo.Id
            };

            users = new List<ApplicationUser>() { userOne, userTwo, userThree, userFour };

            //In-Memory DB
            var options = new DbContextOptionsBuilder<LibraDbContext>()
                .UseInMemoryDatabase(databaseName: "LibraVerseInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new LibraDbContext(options);

            dbContext.AddRangeAsync(users);
            dbContext.AddAsync(publisher);
            dbContext.SaveChanges();

            var userStore = new UserStore<ApplicationUser>(dbContext);
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var optionsUserManager = Options.Create<IdentityOptions>(new IdentityOptions());
            userManager = new UserManager<ApplicationUser>(userStore, optionsUserManager, passwordHasher, null, null, null, null, null, null);

            //Services
            repository = new Repository(dbContext);
            bookService = new BookService(repository);
            publisherService = new PublisherService(repository, bookService);
            userService = new UserService(userManager, repository, publisherService);
        }
        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
            if (userManager == null)
            {
                return;
            }
            userManager.Dispose();
        }

        [Test]
        public async Task Test_UserFullNameAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = userService.UserFullNameAsync(userOne.Id).Result;

            //Assert
            Assert.That(result, Is.EqualTo("Yonni Bonboni"));
        }
        [Test]
        public async Task Test_ExistsByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.ExistsByEmailAsync(userOne.Email);
            var resultNonExisting = await userService.ExistsByEmailAsync("invalid@gmail.com");

            //Assert
            Assert.That(resultExisting, Is.True);
            Assert.That(resultNonExisting, Is.False);
        }

        [Test]
        public async Task Test_ExistsByIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.ExistsByIdAsync(userOne.Id);
            var resultNonExisting = await userService.ExistsByIdAsync("InvalidId");

            //Assert
            Assert.That(resultExisting, Is.True);
            Assert.That(resultNonExisting, Is.False);
        }

        [Test]
        public async Task Test_GetUserByEmailAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.GetUserByEmailAsync(userOne.Email);
            var resultNonExisting = await userService.GetUserByEmailAsync("invalid@gmail.com");

            //Assert
            Assert.That(userOne, Is.EqualTo(resultExisting));
            Assert.That(resultNonExisting, Is.Null);
        }

        [Test]
        public async Task Test_GetUserByIdAsync_ReturnsTheCorrectResult()
        {
            // Act
            var resultExisting = await userService.GetUserByIdAsync(userOne.Id);
            var resultNonExisting = await userService.GetUserByIdAsync("invalidId");

            //Assert
            Assert.That(userOne, Is.EqualTo(resultExisting));
            Assert.That(resultNonExisting, Is.Null);
        }

        [Test]
        public async Task Test_DetailsAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await userService.DetailsAsync(userOne.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(userOne.Id));
            Assert.That(result.FullName, Is.EqualTo(userOne.FirstName + " " + userOne.LastName));
            Assert.That(result.Email, Is.EqualTo(userOne.Email));
            Assert.That(result.IsPublisher, Is.EqualTo(false));
            Assert.That(result.IsAdmin, Is.EqualTo(false));
        }

        [Test]
        public async Task Test_AllAsync_FiltersBySearchTerm()
        {
            // Act
            var result = await userService.AllAsync(userOne.Id, "Ivan");
            var resultTwo = await userService.AllAsync(userOne.Id, "Invalid");


            // Assert
            Assert.That(result.TotalUsersCount, Is.EqualTo(1));
            Assert.That(result.Users.First().Id, Is.EqualTo(userTwo.Id));

            Assert.That(resultTwo.TotalUsersCount, Is.EqualTo(0));
            Assert.That(resultTwo.Users, Is.Empty);
        }

        [Test]
        public async Task Test_AllAsync_FiltersByRoleStatus()
        {
            // Act
            var result = await userService.AllAsync(userOne.Id, null, UserRoleStatus.Publisher);
            var resultTwo = await userService.AllAsync(userOne.Id, null, UserRoleStatus.Admin);

            // Assert
            Assert.That(result.TotalUsersCount, Is.EqualTo(1));
            Assert.That(result.Users.First().Id, Is.EqualTo(userTwo.Id));

            Assert.That(resultTwo.TotalUsersCount, Is.EqualTo(0));
            Assert.That(resultTwo.Users, Is.Empty);
        }
    }
}
