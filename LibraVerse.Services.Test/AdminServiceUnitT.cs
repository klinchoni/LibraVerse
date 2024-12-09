namespace LibraVerse.Services.Test
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    using LibraVerse.Data;
    using LibraVerse.Data.Models.Roles;
    using LibraVerse.Data.Repository;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Services;


    using static LibraVerse.Common.AdminConstants;

    [TestFixture]
    public class AdminServiceUnitT
    {
            //The DB & Services
            private LibraDbContext dbContext;

            private UserManager<ApplicationUser> userManager;
            private RoleManager<IdentityRole> roleManager;
            private IRepository repository;
            private IAdminService adminService;
            private IPublisherService publisherService;
            private IUserService userService;
            private IBookService bookService;

            private IEnumerable<ApplicationUser> users;

            //The User
            private ApplicationUser userOne;
            private ApplicationUser userTwo;

            //The Role
            private Publisher publisher;
            private IdentityRole administratorRole;

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

                publisher = new Publisher()
                {
                    Id = 1,
                    UserId = userOne.Id
                };

                users = new List<ApplicationUser>() { userOne, userTwo };

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

                //Admin Role
                var roleStore = new RoleStore<IdentityRole>(dbContext);
                roleManager = new RoleManager<IdentityRole>(roleStore, null, null, null, null);

                administratorRole = new IdentityRole("Administrator");
                await roleManager.CreateAsync(administratorRole);

                //Services
                repository = new Repository(dbContext);
                bookService = new BookService(repository);
                publisherService = new PublisherService(repository, bookService);
                userService = new UserService(userManager, repository, publisherService);
                adminService = new AdminService(userManager, repository, publisherService, userService);
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


                if (roleManager == null)
                {
                    return;
                }

                roleManager.Dispose();
            }

            [Test]
            public async Task Test_AddPublisherAsync_ReturnsTheCorrectResult()
            {
                // Act
                var result = adminService.AddPublisherAsync(userTwo.Id).Result;
                var publisher = publisherService.GetPublisherByEmailAsync(userTwo.Email).Result;

                //Assert
                Assert.That(result, Is.EqualTo(2));
                Assert.That(dbContext.Publishers.Count(), Is.EqualTo(2));
                Assert.That(publisher.UserId, Is.EqualTo(userTwo.Id));
            }

            [Test]
            public async Task Test_RemovePublisherAsync_ReturnsTheCorrectResult()
            {
                // Act
                var result = adminService.RemovePublisherAsync(userOne.Id).Result;

                //Assert
                Assert.That(result.Id, Is.EqualTo(userOne.Id));
                Assert.That(result.FullName, Is.EqualTo(userOne.FirstName + " " + userOne.LastName));
                Assert.That(result.Email, Is.EqualTo(userOne.Email));
                Assert.That(result.IsPublisher, Is.EqualTo(true));
                Assert.That(result.IsAdmin, Is.EqualTo(false));
            }

            [Test]
            public async Task Test_RemovePublisherConfirmedAsync_ReturnsTheCorrectResult()
            {
                // Act
                var result = adminService.RemovePublisherConfirmedAsync(userOne.Id).Result;
                var publisher = publisherService.GetPublisherByEmailAsync(userOne.Email).Result;

                //Assert
                Assert.That(result, Is.EqualTo(1));
                Assert.That(dbContext.Publishers.Count(), Is.EqualTo(0));
                Assert.That(publisher, Is.Null);
            }

            [Test]
            public async Task Test_AddAdminAsync_ReturnsTheCorrectResult()
            {
                // Act
                var result = adminService.AddAdminAsync(userTwo.Id).Result;

                //Assert
                Assert.That(result, Is.EqualTo(userTwo.Id));
                Assert.That(userManager.IsInRoleAsync(userTwo, AdminRole).Result, Is.True);
            }

            [Test]
            public async Task Test_RemoveAdminAsync_ReturnsTheCorrectResult()
            {
                // Act
                var result = adminService.RemoveAdminAsync(userOne.Id).Result;

                //Assert
                Assert.That(result.Id, Is.EqualTo(userOne.Id));
                Assert.That(result.FullName, Is.EqualTo(userOne.FirstName + " " + userOne.LastName));
                Assert.That(result.Email, Is.EqualTo(userOne.Email));
                Assert.That(result.IsPublisher, Is.EqualTo(true));
                Assert.That(result.IsAdmin, Is.EqualTo(false));
            }

            [Test]
            public async Task Test_RemoveAdminConfirmedAsync_ReturnsTheCorrectResult()
            {
                // Act
                await adminService.AddAdminAsync(userOne.Id);
                var result = adminService.RemoveAdminConfirmedAsync(userOne.Id).Result;

                //Assert
                Assert.That(result, Is.EqualTo(userOne.Id));
                Assert.That(userManager.IsInRoleAsync(userOne, AdminRole).Result, Is.False);
            }
        }
    }