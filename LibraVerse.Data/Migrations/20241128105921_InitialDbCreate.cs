using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Article's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current Article's Title"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "The current Article's Content"),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date on which the current Article was posted"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The current Article's Image Url"),
                    ViewsCount = table.Column<int>(type: "int", nullable: false, comment: "The current Article's Views Count")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current BookStore's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current BookStore's Name"),
                    Location = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current BookStore's Location"),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The current BookStore's Mobile Contact"),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current BookStore's Opening Time"),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current BookStore's Closing Time"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The current BookStore's Image Url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Event's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "The current Event's Topic"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "The current Event's Description"),
                    Location = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "The current Event's Location"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current Event's start date and hour"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current Event's end date and hour"),
                    Seats = table.Column<int>(type: "int", nullable: false, comment: "The current Event's seats"),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Event's Ticket Price"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The current Event's Image Url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Genre's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Genre's Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Article Comment's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "The current Article Comment's Title"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "The current Article Comment's Description"),
                    ArticleId = table.Column<int>(type: "int", nullable: false, comment: "The current Article's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Publisher's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsParticipants",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "The current Event's Identifier"),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current Participant's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsParticipants", x => new { x.EventId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_EventsParticipants_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current Book's Title"),
                    Author = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The current Book's Author"),
                    GenreId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Genre's Identifier"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "The current Book's Description"),
                    Pages = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Pages Count"),
                    YearPublished = table.Column<int>(type: "int", nullable: false, comment: "The date on which the curent Book was published"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Book's Price"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false, comment: "The current Book's cover image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsCarts",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "The current Event's Identifier"),
                    CartId = table.Column<int>(type: "int", nullable: false, comment: "The current Cart's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsCarts", x => new { x.EventId, x.CartId });
                    table.ForeignKey(
                        name: "FK_EventsCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsCarts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Book Review's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Book Review's Title"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "The current Book Review's Description"),
                    Rate = table.Column<int>(type: "int", nullable: false, comment: "The current Book Review's Rate"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksBookStores",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    BookStoreId = table.Column<int>(type: "int", nullable: false, comment: "The current BookStore's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksBookStores", x => new { x.BookId, x.BookStoreId });
                    table.ForeignKey(
                        name: "FK_BooksBookStores_BookStores_BookStoreId",
                        column: x => x.BookStoreId,
                        principalTable: "BookStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksBookStores_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksCarts",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    CartId = table.Column<int>(type: "int", nullable: false, comment: "The current Cart's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksCarts", x => new { x.BookId, x.CartId });
                    table.ForeignKey(
                        name: "FK_BooksCarts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksUsersRead",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The Identifier of the Book"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Identifier of the User"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time when the entity was added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksUsersRead", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BooksUsersRead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksUsersRead_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersCurrentlyReading",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The Identifier of the Book"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Identifier of the User"),
                    CurrentPage = table.Column<int>(type: "int", nullable: false, comment: "The Page the User is on to"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time when the entity was added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCurrentlyReading", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersCurrentlyReading_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCurrentlyReading_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersWantToRead",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The Identifier of the Book"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Identifier of the User"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time when the entity was added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersWantToRead", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersWantToRead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersWantToRead_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "DatePublished", "ImageUrl", "Title", "ViewsCount" },
                values: new object[,]
                {
                    { 1, "Световноизвестният български писател Георги Господинов, автор на бестселъра „Физика на тъгата“, представя новия си роман, озаглавен „Мечтателите“. Книгата, която беше публикувана първоначално в чужбина, вече е достъпна и за българските читатели. Тя разглежда теми за човешката съдба, изборите и парадоксите на съвременното общество. В този нов роман Господинов не само разглежда социалните проблеми, но и вдъхновява читателите да преосмислят възможностите за промяна в личния и обществения живот. Книгата излиза със специална обложка и предговор от самия автор. Тя е в изданието на издателство „Жанет 45“ и струва 22 лева. Някои от най-забележителните творби на Господинов са преведени на повече от 20 езика, а новото му произведение обещава да се нареди сред най-добрите му успехи.", new DateTime(2024, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), "/img/coming-soon.jpg", "Нова книга на Георги Господинов излиза на български пазар", 0 },
                    { 2, "Владимир Николов, волейболен шампион на България, Италия и Франция, златен медалист от Шампионската лига (2005 г.), носител на бронзови медали от Световното (2006 г.) и от Европейското (2009 г.) първенство, диагонал №1 в света (2010 г.), дългогодишен капитан на националния отбор, а сега и президент на ВК „Левски“. Владимир Николов – спортист, съпруг, баща, лидер. Това е неговата откровена до болка история, неговият личен поглед към близкото минало и неговият вдъхновяващ завет как бъдещето да бъде по-добро.", new DateTime(2024, 12, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/v/i/visoko_cover.jpg", "Издават новата книга на Владимир Николов - Високо ", 0 },
                    { 3, "Ще бъде на пазара на цена от 20,70 лв. Ели Мак беше перфектната дъщеря. На петнайсет години, най-малката от три деца, обичана от родителите си, от приятели, от учители. Златно дете. На Ели й оставаха само дни до изпитите и до едно идилично лято с гаджето ѝ. Целият ѝ живот беше пред нея.\r\n\r\nИ след това, изведнъж, нея вече я нямаше.", new DateTime(2025, 1, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/i/-/i-neia-veche-ia-niamashe-front.jpg", "Дебютната книга на авторка Лиза Джуъл -  И нея вече я нямаше", 0 },
                    { 4, "Джон Гришам, майсторът на юридическите трилъри, издаде своя нов роман, озаглавен „Престъплението на века“. В този новоизлязъл роман Гришам разказва историята на адвокат, който попада в една от най-сложните правни битки на живота си, докато разкрива корупция в най-високите етажи на властта. Книгата обещава да бъде наравно с най-добрите му произведения като „Време за убийство“ и „Клетниците“. Изданието е на издателство „Бард“ и вече е в книжарниците.", new DateTime(2025, 1, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), "/img/coming-soon.jpg", "Джон Гришам се завръща с нов трилър – „Престъплението на века“", 0 },
                    { 5, "Феновете на Джордж Р. Р. Мартин ще се радват да разберат, че писателят подготвя нова фентъзи поредица – „Записки за Железния трон“. В първата книга от новата серия, Мартин изследва тъмните тайни на Вестерос и съдбата на онези, които преследват Железния трон, без да се страхуват от последствията. Със сложни герои и непредсказуеми обрати, романът ще задоволи както старите почитатели на автора, така и новите читатели, които търсят нови фентъзи изживявания.", new DateTime(2024, 12, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), "/img/coming-soon.jpg", "Нова поредица от Джордж Р. Р. Мартин – „Записки за Железния трон“", 0 },
                    { 6, "Корицата предстои да бъде заменена с български вариант.", new DateTime(2025, 1, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/t/h/the_strawberry_patch_pancake_house.jpg", "Предстои - The Strawberry Patch Pancake House", 0 },
                    { 7, "Автор: Фредрик Бакман.", new DateTime(2025, 12, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/m/o/moite_priyateli.jpg", "Предстои НОВО - Моите приятели", 0 },
                    { 8, "Петър Кьосев, български писател и историк, представя новия си роман „Времето на звяра“. Книгата е вдъхновена от българската история и разглежда живота през Средновековието, като съчетава факти и художествено въображение. Романът разказва за битките, честта и личните трагедии на героите, които са определяли съдбата на страната. Премиерата на книгата ще бъде на 25 ноември 2024 г. в столичния „Национален дворец на културата“. Изданието е на издателство „Словото“. ", new DateTime(2024, 11, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), "/img/coming-soon.jpg", "Петър Кьосев представя новия си исторически роман „Времето на звяра“", 0 },
                    { 9, "Очаквайте неочакваното.", new DateTime(2024, 12, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/b/l/blue_sisters_-_coco_mellors.jpg", "НОВО издание на авторът Coco Mellors - Blue Sisters ", 0 },
                    { 10, "Елиза Филипова, ново име в българската литература, представя дебютния си роман „Тъмнината на душата“. Това е психологически трилър, който потапя читателя в лабиринта на човешките емоции и тайни. Романът разглежда как човешката психика може да бъде засегната от събития извън контрола на индивида. Книгата ще бъде представена на 22 ноември 2024 г. в София, в книжарница „Хеликон“.", new DateTime(2024, 11, 19, 16, 0, 0, 0, DateTimeKind.Unspecified), "/img/coming-soon.jpg", "Елиза Филипова представя дебютния си роман „Тъмнината на душата“", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7c8eb412-65a9-4050-8c67-62278f3af93c", 0, "004b4de3-fad1-401c-8436-f0a58f8c6668", "guest@gmail.com", false, "Petya", "Guesta", false, null, "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAIAAYagAAAAENRLS9CuPFfq/TVfxPHVMjeNiBbFuOPyTkiRSTmChTQ+JScNw3YEnQX1rkEcf9DN5g==", null, false, "5a553126-0539-4978-9e16-913db0574990", false, "guest@gmail.com" },
                    { "8482124a-1681-41b9-81bd-83e20223d345", 0, "1ca1063f-f634-4826-87da-ac8bde5070b6", "admin@gmail.com", false, "Klinchoni", "Boss", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBtqIwDsaClG0A9F0i4eYAuYjti7gZ/WcwJg7iKPC4vaS2hF9k72dNZUmLbfW7FjNQ==", null, false, "afe58646-f82b-42d7-8d1a-e91a8551dc33", false, "admin@gmail.com" },
                    { "9abf1366-cadf-4837-bc30-1b77599ff9cb", 0, "e8e7f497-ad15-4a3c-959b-6975109ab953", "publisher@gmail.com", false, "Nasko", "Publisher", false, null, "PUBLISHER@GMAIL.COM", "PUBLISHER@GMAIL.COM", "AQAAAAIAAYagAAAAEDfBCFT+bfqSc6NUbrinIenUYkwlRF14yjFalJhGJ0OcYDKh1aYx6iJcJWNnXNlHsw==", null, false, "a2dc3247-dd5b-4372-9058-cc9ae7a462e7", false, "publisher@gmail.com" },
                    { "b4a1311e-dff4-4c3a-9cf7-b794557bdf80", 0, "8faea654-150c-450e-b649-3421da7e2851", "ivankl@gmail.com", false, "Ivan", "Best", false, null, "IVANKL@GMAIL.COM", "IVANKL@GMAIL.COM", "AQAAAAIAAYagAAAAEDikhYy6XjcKCEy4ucrQhe3dQmztfUcfRsFtLRtFBiJi/VTXTY+Ypv0bzYGDHxwbMQ==", null, false, "f7f91a47-33dd-4ba2-9446-cc04f6d39293", false, "ivankl@gmail.com" },
                    { "c4fbe2f71-126f-46c3-af99-8dc035eac772", 0, "c8fc7614-6d85-4067-9165-b21b37684162", "yonni@gmail.com", false, "Yonni", "Bonboni", false, null, "YONNI@GMAIL.COM", "YONNI@GMAIL.COM", "AQAAAAIAAYagAAAAEFouWeaGHPjQsMUVUt3B0nN7ctwsjYdYUmOwn10FZo6DQrbLKah3WPTL+5TwFCpp9A==", null, false, "cb6f6daa-3c75-4b92-9243-711730840819", false, "yonni@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "BookStores",
                columns: new[] { "Id", "ClosingTime", "Contact", "ImageUrl", "Location", "Name", "OpeningTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 28, 20, 30, 0, 0, DateTimeKind.Unspecified), "+359 88 651 1944", "https://lh3.googleusercontent.com/p/AF1QipOEsGmlKTuS7Nog7kX9vQfcWBwxw5tyAloSvkMz=s1360-w1360-h1020-rw", "бул. Цар Освободител 22, 1000 София, България", "Ciela - София", new DateTime(2024, 11, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 11, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), "+359 56 800 620", "https://lh3.googleusercontent.com/p/AF1QipPs7hpPMTum4GJ7Iny4YCZLVYiZeh0ljXxykOiQ=s1360-w1360-h1020-rw", "Бургас Център, ул. „Тройката“ 4, 8000 Бургас", "Helikon - Бургас", new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), "+359 88 403 2576", "https://lh3.googleusercontent.com/p/AF1QipPQqWlmrzQ2BrBpRpyshwBFFeLofJKUlGeCIDf3=s1360-w1360-h1020", "Хладилника, бул. „Черни връх“ 100, 1407 София", "Orange - Paradise Center", new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 11, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), "+359 32 207 621", "https://cdn.oink.bg/gallery/23010/05adf581-0397-4f92-a9fa-65a087cd918f_large.webp", "ул. „Княз Александър I-ви“ 29, 4000 Пловдив", "Helikon - Пловдив Център", new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 11, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), "+359 74 780 568", "https://web-portalbg.com/media/data/official_reskin_data/images2500/test_folder/1153/Logo/logo.jpg", "ул. „Шейново“ 6, 2760 Разлог", "Дъга - Разлог", new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 11, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), "+359 89 699 7710", "https://lh3.googleusercontent.com/p/AF1QipPzW0X4Y2MxHq2gWA7Db5RAe4FgFzdhySCLPc-6=s1360-w1360-h1020-rw", "Ларго, ул. „Тодор Александров“ 2, 2700 Благоевград", "Хермес", new DateTime(2024, 11, 28, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 11, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), "+359 87 922 8009", "https://lh3.googleusercontent.com/p/AF1QipOoQHzIG3B8LxmxLjyoCSlDD93L6ftaFLVYFWzX=s680-w680-h510-rw", "Варна Център Одесос, ул. „Цар Симеон I“ 1, 9000 Варна", "Bookpoint - Варна", new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 11, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), "+44 20 7851 2400", "https://lh3.googleusercontent.com/p/AF1QipO70gybohOeMNg3RDqh-tICLGqJIkeRoDEEBfOS=s1360-w1360-h1020", "203-206 Piccadilly, London W1J 9HD, UK", "Waterstones - Piccadilly", new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), "+55 11 3813-2731", "https://images.adsttc.com/media/images/55f6/eac2/adbc/0118/6200/02bf/newsletter/room-surrounded-with-bookshelfs-on-the-ground-floor-and-undergro.jpg?1442245289", "Rua dos Três Irmãos, 11, Vila Progredior, São Paulo - SP, Brazil", "Livraria da Vila", new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), "+54 11 4813-6052", "https://indiehoy.com/wp-content/uploads/2019/01/ateneo-640x426.jpg", "Av. Santa Fe 1860, C1425BTH, Buenos Aires, Argentina", "El Ateneo Grand Splendid", new DateTime(2024, 11, 28, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), "+1 415-362-8193", "https://upload.wikimedia.org/wikipedia/commons/f/fb/City_Lights_Booksellers.jpg", "261 Columbus Ave, San Francisco, CA 94133, USA", "City Lights Booksellers", new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2024, 11, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), "+61 2 9264 6654", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1a/c7/bd/a4/street-level-showing.jpg?w=1200&h=-1&s=1", "424 George St, Sydney NSW 2000, Australia", "Dymocks - Sydney", new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2024, 11, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), "+44 20 7437 5660", "https://cdn.foyles.co.uk/uat/images/00243704-1200x925.png", "107 Charing Cross Rd, London WC2H 0DT, UK", "Foyles - Charing Cross", new DateTime(2024, 11, 28, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2024, 11, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), "+351 22 200 2037", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/fa/10/7d/20200910-113406-largejpg.jpg?w=1200&h=-1&s=1", "Rua das Carmelitas 144, 4050-161 Porto, Portugal", "Livraria Lello", new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), "+86 10 6500 2676", "https://www.thatsmags.com/image/view/201806/the-bookworm.jpg", "4 Sanlitun Nan Lu, Chaoyang, Beijing, China", "The Bookworm", new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "ImageUrl", "Location", "Seats", "StartDate", "TicketPrice", "Topic" },
                values: new object[,]
                {
                    { 1, "На 17 октомври (четвъртък) 2024 г., от 13:30 ч. ще се проведе събитите: Цял месец, посветен на Хари Потър не ни е достатъчен, затова имаме изненада за вас! За поредна година ще отбележим Деня на книгите за Хари Потър.", new DateTime(2024, 10, 17, 16, 30, 0, 0, DateTimeKind.Unspecified), "https://www.libsofia.bg/public//storage/uploads/event/NyEfL4aR00tRO530JbTSI7tbIRhrioTFLnOhXTCV.png", "Столична библиотека, София", 90, new DateTime(2024, 10, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), 10m, "Ден на книгите за Хари Потър" },
                    { 2, "Анимационният типаж е най-важният компонент в анимационния разказ. Това е всъщност главният герой на рисувания филм, плод на творческите търсения на неговите „родители“ – режисьора и художника. Настоящото изследване проследява появата и развитието му от зората на анимационното кино до наши дни. Книгата съдържа повече от 1000 илюстрации и представлява интерес както за студенти и професионалисти в областта на анимацията, така и за всички любители на изкуството.", new DateTime(2024, 11, 20, 19, 30, 0, 0, DateTimeKind.Unspecified), "https://azcheta.com/azcheta-content/uploads/2024/11/73-NBU-v-tsentara-Animatsionniyat-tipazh-20.11.jpg", "НБУ В ЦЕНТЪРа, ул. „Георги С. Раковски“ 191 Б, София", 80, new DateTime(2024, 11, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), 15m, "Представяне на книгата на д - р Пенчо Кунчев, Анимационният типаж: 1906 - 2012" },
                    { 3, "Столична библиотека организира в Американския център паметна вечер по случай 110 години от рождението на големия български писател и кинодраматург Павел Вежинов. В програмата са включени премиери на 9-ото издание на „Нощем с белите коне“, на неиздаваните от повече от 80 години два дебютни сборника с разкази на Павел Вежинов в авторска редакция „Улица без паваж. Дни и вечери“ и най-новото издание на Столична библиотека „Павел Вежинов – биобиблиография“. Ще бъде представена фотодокументалната изложба на Библиотеката, представяща сложния житейски и творчески път на писателя. В паметната вечер с водещ Юрий Дачев ще участват съвременници на Павел Вежинов – известни литератори и филмови творци, издателите Игор Шемтов от „Фама 1“ и Савина Николова от „Orange books“, изследователи на творчеството му. Вечерта ще завърши с прожекция на един от най-интересните документални филми за Павел Вежинов „Сини залези и бели коне“ на БНТ.", new DateTime(2024, 11, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), "https://azcheta.com/azcheta-content/uploads/2024/11/Vezhinov.jpg", "Американски център на Столична библиотека, пл. Славейков №4, София", 200, new DateTime(2024, 11, 20, 18, 30, 0, 0, DateTimeKind.Unspecified), 20m, "Паметна вечер по случай 110 години от рождението на Павел Вежинов" },
                    { 4, "Като кадри от филм се редуват сцени от живота на две българки във Франция в началото на новия век. Въоръжена с „Големия енциклопедичен речник Ларус“ и „Малкия Ларус на добрите обноски“, студентката по кино в Лион открива „страната на свободата, на сирената и на говорещите трамваи“, бори се с тънкостите на френския език, сблъсква се и с едно особено отношение към „момичетата от Изтока“. Разказани увлекателно, с хумор и самоирония, перипетиите ѝ са контрапункт на съдбата на втората героиня. Дора, самотна майка на две момчета, преминала през възродителния процес и безчет житейски несгоди в България, попаднала в мрежа на трафиканти, е принудена да проституира. Борбената Дора, в чийто живот светъл лъч внася само „вълшебната лампа“ на баба ѝ Арифе, също се вписва в разпространеното клише „момиче от Изтока“. Един ден пътищата на двете героини неочаквано се пресичат…", new DateTime(2024, 11, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2024/11/egeorgieva_event.jpg", "Зала „Славейков“ на Френския институт", 30, new DateTime(2024, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified), 50m, "Премиера | „Одисея на момичетата от Източна Европа“ на Елица Георгиева" },
                    { 5, "В този внушителен по обем и времеви обхват литературен труд, който авторът е нарекъл „Моите истории“, а някои биха го определили като своеобразен „дневник на писателя“, Георги Борисов представя непубликувани свои стихотворения, мисли и наблюдения, философски есета и мемоарна проза, литературни портрети и свидетелства, сценки и житейски истории, белязали неговия път в продължение на половин век. Сред най-любопитните от разделите в настоящия том е първият – и като форма, и като тематика, – който препраща към Далчевите „Фрагменти“ и представлява особен принос с „опитите“ на поета да разгадае същността на поезията и творческия процес, многоликите маски на битието и холограмите на словото, безкрайните възможности и измамната нищета на българската рима.", new DateTime(2024, 11, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2024/11/borisov_event.jpg", "Софийска градска художествена галерия", 150, new DateTime(2024, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified), 30m, "ПРЕМИЕРА | МОИТЕ ИСТОРИИ от Георги Борисов" },
                    { 6, "„Анархия на сърцето“ е царицата на меланхолиите и обречената любов, но и оголен до рана нерв, който води до удобно премълчаваните въпроси за социалното неравенство и липсата на човешкото в социума, за вируса на страха и самотата, за забравата на миналото и отричането на бъдещето, за ужаса на войната, за самотната вечеря на Бога, за разрухата на сърцето... Тази книга е юмрук право в кривите зъби на мълчанието ни, опит за редакция на света, но и любов към ближния, към поезията и към свободата да обичаш до смърт.", new DateTime(2024, 11, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://kulturni-novini.info/news/images/40166_1.jpg", "Gramophone Live&Event Club, ул.Будапеща 6 - София", 70, new DateTime(2024, 11, 7, 19, 30, 0, 0, DateTimeKind.Unspecified), 25m, "Анархия на сърцето: Премиера на дългоочакваната втора поетична книга на Александър Иванов" },
                    { 7, "На 6 ноември (сряда) от 17.30 часа, в залата на Регионална библиотека „Стилиян Чилингиров” – Шумен  ще се състои премиера на книгата „НаПРАВО в живота” на Румяна Мичева. Книгата ще представи проф. Теменуга Тенева, откъси от творбата ще прочете Ирина Николова.", new DateTime(2024, 11, 6, 18, 30, 0, 0, DateTimeKind.Unspecified), "https://kulturni-novini.info/news/images/40141_1.jpg", "Регионална библиотека Стилиян Чилингиров - Шумен", 60, new DateTime(2024, 11, 6, 17, 30, 0, 0, DateTimeKind.Unspecified), 10m, "Премиера на книгата „НаПРАВО в живота” на Румяна Минчева" },
                    { 8, "Заповядайте на официалната премиера на Ръцете, с които оцеляваме - втората стихосбирка на талантливата Боряна Богданова.", new DateTime(2024, 11, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), "https://kulturni-novini.info/news/images/40135_1.jpg", "Rоckbar158 - София", 80, new DateTime(2024, 11, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 23m, "Премиера на Ръцете, с които оцеляваме - новата стихосбирка на Боряна Богданова" },
                    { 9, "Любен Дилов ще представи дебютната книга на Калина Серкеждиева Нишки. Няколко думи ще кажат: Стойко Стоянов, Мира Радева, Азиз Таш. Откъси от книгата ще прочете актрисата Петя Бончева. \r\n\r\nЗа доброто ни настроение ще се погрижат: Two cities one world, Александър Иванов (пиано и вокал). Вокал: Анна Янова. Фотограф: Тихомира Методиева-Тихич. Камера: Димитър Григоров. Водещ: Алина Караханова. Заповядайте на чаша вино и топли приказки!", new DateTime(2024, 10, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), "https://kulturni-novini.info/news/images/40081_1.jpg", "гр. София, ул. Ангел Кънчев 31, редакцията на списание L'Europeo", 130, new DateTime(2024, 10, 29, 19, 30, 0, 0, DateTimeKind.Unspecified), 50m, "Лексикон представя дебютния сборник с разкази - Нишки от Калина Серкеджиева" },
                    { 10, "Заповядайте на официалната премиера на дебютния сборник с разкази на София Стойнева в уютното пространство на конферентната зала на хотел \"Елит\".\r\n ", new DateTime(2024, 10, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), "/img/coming-soon.jpg", "Конферентна зала на хотел Елит, гр. Перник", 100, new DateTime(2024, 10, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Нещо за подарък. Премиера на дебютния сборник с разкази на София Стойнева" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Приключенски" },
                    { 2, "Изкуство" },
                    { 3, "Автобиография" },
                    { 4, "Бизнес" },
                    { 5, "Детска литература" },
                    { 6, "Класическа литература" },
                    { 7, "Кулинарни" },
                    { 8, "Криминален" },
                    { 9, "Драма" },
                    { 10, "Фентъзи" },
                    { 11, "Художествена литература" },
                    { 12, "Историография" },
                    { 13, "История" },
                    { 14, "Хорър" },
                    { 15, "Хумор" },
                    { 16, "Военни" },
                    { 17, "Музика" },
                    { 18, "Митология" },
                    { 19, "Философия" },
                    { 20, "Поезия" },
                    { 21, "Политическа литература" },
                    { 22, "Любовен" },
                    { 23, "Сатира" },
                    { 24, "Наука" },
                    { 25, "Научна фантастика" },
                    { 26, "Разкази" },
                    { 27, "Трилър" }
                });

            migrationBuilder.InsertData(
                table: "ArticleComments",
                columns: new[] { "Id", "ArticleId", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 4, "Джон Гришам е любимият ми автор, няма търпение да се потопя в новия му трилър.", "Невероятен Гришам!", "7c8eb412-65a9-4050-8c67-62278f3af93c" },
                    { 2, 5, "Отдавна чакам Мартин да пусне нещо ново. Надявам се да е толкова завладяващо, колкото „Игра на тронове“.", "Време беше!", "c4fbe2f71-126f-46c3-af99-8dc035eac772" },
                    { 3, 4, "Юридическите драми не са за мен, но уважавам Гришам за таланта му.", "Не е моето", "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 4, 6, "Очаквам да видя какво ли ще бъде!.", "Хмм, нещо различно!", "b4a1311e-dff4-4c3a-9cf7-b794557bdf80" },
                    { 5, 5, "Джордж Р. Р. Мартин започва нова поредица, а още не е завършил 'Песен за огън и лед'... малко разочароващо.", "Нека първо завърши старото", "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 6, 6, "Какво трябва да очакваме?", "Няма никакво описание!", "c4fbe2f71-126f-46c3-af99-8dc035eac772" },
                    { 7, 7, "„Моите приятели“ звучи като че ли са ни останали някакви приятели в днешно време? Ще я прочета веднага щом се появи на пазара!", "Звучи заинтригуващо", "7c8eb412-65a9-4050-8c67-62278f3af93c" },
                    { 8, 7, "Според мен ще бъде бест селър.", "Охо, това ми хареса!", "c4fbe2f71-126f-46c3-af99-8dc035eac772" },
                    { 9, 8, "„Времето на звяра“ изглежда като книга, която ще вдъхне живот на забравени исторически епохи. Страхотно, че има такива проекти!", "Българската история в литературата", "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 10, 10, "Очаквам с фолямо вълнение този роман. Звучи чълнуващо и истински докосващо!", "Най-после нещо ново! :)", "c4fbe2f71-126f-46c3-af99-8dc035eac772" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Klinchoni Boss", "8482124a-1681-41b9-81bd-83e20223d345" },
                    { 2, "user:fullname", "Nasko Publisher", "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 3, "user:fullname", "Petya Guesta", "7c8eb412-65a9-4050-8c67-62278f3af93c" },
                    { 4, "user:fullname", "Ivan Best", "b4a1311e-dff4-4c3a-9cf7-b794557bdf80" },
                    { 5, "user:fullname", "Yonni Bonboni", "c4fbe2f71-126f-46c3-af99-8dc035eac772" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "GenreId", "ImageUrl", "Pages", "Price", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, "Джек Лондон", "Разказва се за южняшкото куче Бък, което попада сред дивия север. След много битки с Шпиц, теглене на тежки пощенски шейни, неприятности с алчни хора, Бък открива Джон Тортън. Бък му остава верен до гроб, но дивите му истинкти надделяват и той често изчезва от лагера. Един ден той се връща от лов и вижда господаря си убит от ихатите. По-късно той се присъединява към глутница вълци. ", 1, "https://i2.helikon.bg/products/4956/05/54956/0658229_b.jpg?t=1732090822", 128, 5.00m, "Дивото зове", 1903 },
                    { 2, "Паисий Хилендарски", "Има една книга, която винаги ще намери място в българския дом. На вашето внимание представяме луксозно фототипно издание на една от най-ценните родни творби – „История славянобългарска“ от Паисий Хилендарски. Достойнството на това издание е преводът на новобългарски. Той следва ред по ред Котленския препис на Софроний Врачански, представен чрез факсимилета на всяка страница. По този начин читателят може да вникне пълноценно в историческото повествование, четейки и сравнявайки написаното от хилендарския монах. Нещо повече  – използван е официално одобреният превод от Зографската света обител, дело на изтъкнатия преподавател в катедра „Кирилометодиевистика“ в Софийския университет ас. д-р Димитър Пеев. Съвместно с проф. Александър Николов, той е автор и на научния коментар. Изданието се реализира в сътрудничество със Зографската света обител и Националната библиотека Св. св. Кирил и Методий.", 12, "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/i/s/istoria-slavianobylgarska.jpg", 240, 30.00m, "История славянобългарска", 1762 },
                    { 3, "Жул Верн", "В един привидно нормален ден в ексклузивния клуб Reform, Филиас Фог, джентълмен с голямо богатство и взискателни вкусове, прави изключителен залог от £20 000; той ще извърши невъзможен подвиг и ще обиколи земното кълбо само за осемдесет дни. Придружен само от новия си френски камериер, упорития Паспарту, той тръгва на вълнуващо пътешествие. Следват приключения, хаос и романтика, докато Фог и Паспарту използват новата сила на парата, за да избягат от непрекъснато увеличаващите се врагове и да изпреварят времето.", 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/Verne_Tour_du_Monde.jpg/330px-Verne_Tour_du_Monde.jpg", 280, 25.90m, "Около света за осемдесет дни", 1873 },
                    { 4, "Херодот", "Уважаеми читателю,Историята на Херодот е забележително и увлекателно описание на персийските войни на царете Кир, Дарий, Камбис и Ксеркс, син на Дарий. С големи подробности е описана войната на персите с елинските градове държави, водена от цар Ксеркс, която започва през 499 г. пр.н.е. и продължава до 449 г. пр.н.е. Тази история е написана под формата на художествен разказ, наситен с исторически сведения, предания, легенди, преплетени с вярванията в системата от богове на елини и перси. Особен интерес за българската история представляват сведенията за тракийските народи, дадени във връзка с различни събития. За изучаващите историята на Европа и в частност на България тази книга е задължително четиво. Херодот е роден около 484 г. пр.н.е. в Халикарнас, в областта Кария в Мала Азия, по негово време градът е васал на Персия, и умира около 425 г. пр.н.е., така че той е съвременник на войната на Ксеркс, което прави сведенията му неоценимо полезни. Изучавайки този обемист литературно-исторически труд и огромното количество дискусии върху него, човек неминуемо се смущава от това, че Херодот бива наричан първи историк, бащата на историята и т.н. Не е възможно да се появи по онова време такъв забележителен труд без по негово време да е имало множество предшественици и съвременници, писали по подобен начин, но просто неумолимото време е съхранило за нас само този труд. През 1888 г. Ф. Г. Мищенко превежда на руски Историята на Херодот разделяйки я на два тома. Превод от старогръцки на български на избрани пасажи се появяват в Извори на старата история на Тракия и Македония, София, 1949 г., превод на Г. Кацаров и Б. Геров, Извори за историята на Тракия и траките, том 1, БАН, София, 1981, превод Иван Венедиков и Д. Бояджиев, а също и в превода на Д. Гетов, в Херодот, Исторически новели, Народна култура, София, 1982.Пълен превод на Историята на Херодот на български публикува Петър Ангелов Димитров: през 1986 г. първи том, а през 1990 г. втори том, използвайки английско и френско издание на старогръцкия текст на Историята. През 1972 г. Г. А. Стратановски прави нов превод от старогръцки. Този превод на руски е публикуван в интернет през 2008 година. Настоящето издание е превод от руски, като в случаи на съмнения е правена справка с превода на Димитров. Прави впечатление, че смисълът на всички пасажи е идентичен, но има някои разлики в изписването на персийските и елински имена. Д-р Николай Иванов Колев, 15.8.2024 - Херцогенаурах, Германия", 13, "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/h/e/herodot-istoria.jpg", 810, 50.00m, "История на Херодот", 1888 },
                    { 5, "Николай Райнов", "„История на изкуството“ на Николай Райнов е грандиозен, несравним по своята всеобхватност и дълбочина труд, оказал огромно влияние върху развитието на българската култура. Блестящ ерудит, белетрист и поет, график и декоратор, историк и стилист, изследовател и философ, авторът проследява промените през различните епохи – от най-древните времена до началото на XX век – и изразяването на човешкия дух чрез изкуството.", 2, "https://i2.helikon.bg/products/6357/24/246357/246357_b.jpg?t=1732093233", 808, 98.00m, "История на изкуството", 2024 },
                    { 6, "Астрид Линдгрен", "Астрид Линдгрен (1907-2002) е написала три романа за червенокосата Пипи: \"Пипи Дългото чорапче\" (1945), \"Пипи се качва на кораба\" (1946) и \"Пипи в южните морета\" (1948). През 1968 г. на български език се появява книга със заглавие \"Пипи Дългото чорапче\". В нея, както и в по-следващите й издания, са включени част от разказите за Пипи от трите романа. И по-точно - 24 от общо 32 глави. Така близо една трета от историите за червенокосото момиче остават непознати за нашия читател. В настоящото издание е събрана цялата трилогия за Пипи. За първи път на български език се публикуват главите: - Пипи се бори с огнена стихия - Пипи още живее във Вила Вилекула - Пипи пише писмо и пак тръгва на училище - но за малко... - И Пипи отива на училищен излет - Пипи на панаир - Пипи си остава във Вила Вилекула - Пипи разведрява леля Лаура", 5, "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/f/i/file_267_80.jpg", 352, 10.90m, "Пипи Дългото чорапче", 2017 },
                    { 7, "Марк Твен", "За Том Сойер, Хъкълбери Фин и Беки животът край Мисисипи е непрекъснат низ от приключения, истински опасности и дори скрито съкровище, Да ги проследим заедно, водени от изкусния разказвач Марк Твен.", 5, "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/9/7/9786192440992.jpg", 92, 19.90m, "Класика за деца - Приключенията на Том Сойер", 2024 },
                    { 8, "Айзък Азимов", "Един от най-великите научнофантастични романи, в който се разказва за разпадането на Галактическата империя и опитите на Хари Селдън да съхрани знанията на човечеството чрез създаването на Фондацията.", 24, "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/k/o/33e0e63922387923bfa42e3bec9f7e2c/kolektsiya-fondatsiya-30.jpg", 296, 18.90m, "Фондация", 1951 },
                    { 9, "Ане Франк", "Дневникът на едно младо момиче, криещо се от нацистите в Амстердам. Този запис на надеждите, страховете и мислите ѝ е станал символ на човешката издръжливост.", 9, "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ane-frank-zadnata-kyshta-ciela-9789542827214.jpg", 340, 12.00m, "Дневникът на Ане Франк", 1947 },
                    { 10, "Мигел де Сервантес", "Историята на рицаря от Ла Манча, който тръгва на приключение със своя оръженосец Санчо Панса. Сатиричен разказ за идеалите и реалността.", 6, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/7/9/79588.jpeg", 1072, 22.90m, "Дон Кихот", 1605 },
                    { 11, "Алая Доун Джонсън", "След като Земята е сполетяна от бедствия и разруха, оцелелите в Бразилия построяват града пирамида Палмареш Треш, в който жените управляват и периодично се избира Крал само за една година. Той трябва да посочи следващата Кралица, преди да бъде принесен в жертва. Непокорната и талантлива Джун Коста е запленена от последните избори и с всички средства подкрепя Анки, красиво момче от най-долното ниво на града. След като той печели, Джун и най-добрият й приятел Жил попадат в света на новия Крал. Енки е ярка и бързо изгряваща звезда, чиято светлина отваря очите на Джун за сериозните проблеми на Палмареш Треш. Двамата създават произведения на изкуството, които градът никога няма да забрави, и разпалват искрата на недоволството срещу властта. Под звуците на самба всички се впускат в танц на живот и смърт, в който залогът е бъдещето.", 10, "https://knizhen-pazar.net/books/088/8809/880919.jpg?size=22461", 336, 15.00m, "Летният принц", 2014 },
                    { 12, "Х. Д. Карлтън", "Аделайн се настанява в някога внушителното, но сега западнало имение „Парсънс“, което е наследила от баба си. Успешна писателка, надарена с богато въображение, тя се чувства съвсем на място сред готическата атмосфера на къщата и тайните, скътани във всяка паяжина. А когато случайно се натъква на дневника на прабаба си Джиджи, намерена мъртва в къщата преди повече от шейсет години, разбира, че може би е открила и ключа към мистерията кой я е убил.\r\n\r\nНо по-голямата загадка сякаш е кой е тайнственият непознат, който наблюдава къщата ѝ, преследва мъжете, осмелили се да я погледнат, и оставя червени рози в спалнята ѝ.\r\n\r\nИ защо, вместо да потърси помощ от полицията, Аделайн се наслаждава да го предизвиква?", 22, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/p/u/purva-adeline-latest.jpg", 624, 30.00m, "Преследването на Аделайн - книга 1", 2024 },
                    { 13, "Лорън Робъртс", "Ловец. Жертва. Обречени един за друг.\r\n\r\nЕдинствено необикновените имат място в кралство Илиа…\r\n\r\nОт десетилетия Елитните притежават своите сили, придобити благодарение на Чумата, докато Обикновените са изолирани от обществото и прокуждани от кралството.\r\n\r\nНикой не е изпитал това на гърба си по-добре от Пейдин Грей, Обикновена, която се представя за Ясновидец, за да се слее с тълпата от Елитни. Когато Пейдин, без да подозира, спасява живота на един от принцовете на Илиа, тя е включена против волята си в Изпитанията на Прочистването – жестока, кървава надпревара, превърната в демонстрация на силата на Елитните.\r\n\r\nАко противниците ѝ в Изпитанията не я убият, това ще направи принцът, с чувствата си към когото Пейдин напразно се опитва да се бори… А той непременно ще я убие, ако разбере, че тя е Обикновена.\r\n\r\nПотопете се в първия том от епичната фентъзи трилогия „Безсилна“ на Лорън Робъртс, изпълнена с приключения и романтика, която покори целия свят…\r\n\r\n", 10, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/_/-/_-__478.jpg", 528, 25.00m, "Безсилна", 2024 },
                    { 14, "Димитър Цолов", "В сборника с ужаси от български автори \"Измерения на болката\" са включени разкази от:\r\n\r\nАлекс Цонков, Анна Гюрова, Димитър Маргаритов, Димитър Цолов, Елена Зелена Бърдарова, Елена Павлова, Мария Пеева, Мария Раднева, Милен Димитров, Нина Митева, Ралица Пейкова, Явор Цанев. Съставител и редактор е Милен Димитров. Разказите са маркирани с тагове за улеснение на читателя.\r\n\r\n...Историите се носят през пространство-времето, като преплитат в себе си минало, настояще и бъдеще, фентъзи, фантастика, паралелни светове и реализъм, а страхът в тях се проявява освен във фантастичното и непонятното, така и в чисто човешкото битие, където разноликите герои влизат в схватка както с външни сили, така и със самите себе си...", 14, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/_/-/_-_-_9786197771237_-_-_ciela.jpg", 304, 20.00m, "Измерения на болката", 2024 },
                    { 15, "Дженифър Лин Барнс", "Седем билета. Остров сред океана. Шанс, който се пада един път в живота.\r\n\r\nДобре дошли в „Най-великата игра“, ослепителното, променящо животи състезание, организирано от Ейвъри Грамс и четиримата скандално известни братя Хоторн. Създадена, за да предложи шанс за слава и богатство, тазгодишната игра е ограничена до седем късметлии.\r\n\r\nЛИЙРА е преследвана от смъртта на баща си и тайните, които е оставил след себе си. Тя си казва, че се е включила в състезанието заради наградата, а не, за да получи отговори относно участието на семейство Хоторн в трагичния край на баща ѝ и категорично не, за да се изправи срещу вбесяващия, загадъчен Грейсън Хоторн, когото вече е отхвърлила веднъж\r\n\r\nСрещу Лийра се изправят ДЖИДЖИ, полусестрата на Грейсън и истински слънчев лъч, решена да докаже, че е способна на повече, отколкото останалите смятат, и РОХАН, който има много малко морални задръжки, опасни и еклектични умения и никакво бъдеще - освен ако не спечели играта.\r\n\r\nЗахвърлени на частен остров, сред лукс и загадки за разрешаване, Лийра, Джиджи и Рохан трябва да направят всичко, на което са способни, за да надделеят един над друг, да се справят с останалите си страховити съперници и да победят в игра, която само най-острите умове биха могли да спечелят. Прехвърчат искри, предизвикателства тласкат участниците до предела на силите им, а всеки един от тях пази тайни, които няма как да останат погребани завинаги.\r\n\r\n", 27, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/g/r/grandestgame_bg_cv_front1728926839.7707.jpg.jpeg", 368, 19.90m, "Най-великата игра", 2024 },
                    { 16, "Петър Петров", "Книгата \"Счетоводство и финанси за нефинансови мени¬джъри\" ви предоставя лесен начин за разбиране на иначе сложната материя, свързана със счетоводството и финансите – до минималното ниво, което е необходимо на всеки нефинансов мениджър. Книгата може да бъде полезна и за изучаващите финанси, финансово и управленско счетовод¬ство, които срещат практически трудности в разбирането на тази материя. Книгата е структурирана в седем глави, представени под формата на уроци, запознаващи читателите с основните аспекти на активите, пасивите, приходите и разходите – както по отношение на тяхната същност и счетоводно отчитане, така и по отношение на икономическата и финансовата трактовка на свързаните с тях показатели.\r\nДнес новините изобилстват от примери за това до какво може да доведе липсата на минимални познания по счетоводство и финанси – кредитиране в швейцарски франкове при доходи в левове, договаряне на нереално високи преференциални лихви и др. За всички, които не желаят да бъдат част от тези новини, книгата \"Счетоводство и финанси за нефинансови мениджъри\" ще бъде учебното помагало, което съчетава хармонично необходимия минимум от теория на счетоводството и финансите със задължителния практикум за лесно усвояване на такива знания и неусетното им превръщане в умения.", 4, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/1/9/198677_b.jpg", 220, 20.00m, "Счетоводство и финанси за нефинансови мениджъри", 2016 },
                    { 17, "Зорница Русева", "В тази книга Ръсел Брънсън, съосновател и изпълнителен директор на мултимилионната компания ClickFunnels, разкрива класическите основополагащи техники за директен маркетинг, които ще ви сложат на челно място сред успешните бизнес компании, ще ви посочат възможности, каквито мнозина пропускат да забележат, и ще ви обучат как да се отличавате от всички останали играчи.\r\n\r\nС инструкции стъпка по стъпка Брънсън ще ви научи да управлявате множество трафик източници, както и да прилагате пазарно проверени стратегии, за да:\r\n\r\nидентифицирате вашите мечтани клиенти;\r\nоткривате къде те вече се събират онлайн;\r\nсъздадете собствена платформа за публикуване;\r\nсъставите собствени списъци за разпространение.", 4, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/_/-/_-__453.jpg", 344, 29.99m, "Тайните на трафика", 2024 },
                    { 18, "Иън Хaлпърин", "На 24 декември 2008 г. световните медии публикуват скандалното заявление на разследващия журналист Иън Хaлпърин, че на Майкъл Джексън му остава половин година живот. Официалният говорител на звездата определя твърдението като „пълна измислица”. Шест месеца и един ден по-късно светът е разтърсен от новината за смъртта на Краля на попа.", 17, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/1/0/104198.jpeg", 376, 14.95m, "Истината за последните години от живота на Майкъл Джексън", 2009 },
                    { 19, "Георги Владимиров", "Книгата „Българите на Волга“ е продукт на дългогодишните проучвания на д-р Г. Владимиров върху историята и културата на българите от заселването им в земите на Средна Волга през VIII в. до унищожаването на техния културен модел през втората половина на XVI в. На базата на писмени извори, археологически, етнографски и антропологически данни изданието проследява политическата и стопанската история, бита, материалната и духовната култура на населението на Волжка България, Златната орда и Казанското ханство.\r\n\r\n", 13, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/b/u/bulgarite_na_volga-hrm.jpg", 248, 20.00m, "Българите на Волга", 2024 },
                    { 20, "Йозеф Киршнер", "Манипулативната игра има свои правила и всеки, който иска да осъществи себе си, трябва да ги овладее. Книгата е предизвикателство за всички, които не искат да бъдат пасивни жертви на манипулацията, а съзнателно и целенасочено да се утвърждават във всекидневното общуване. Всеки има шанс да стане господар на съдбата си стига само да поеме инициативата.\r\n\r\n", 19, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/m/a/manipuliraite-no-pravilno-josef-kirshner-kibea.jpg", 236, 18.00m, "Манипулирайте, но правилно - Осемте закона на въздействието върху хората", 1995 },
                    { 21, "Бевърли Глок", "Епичен роман за руското общество по време на Наполеоновите войни.", 7, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/5/0/500__7.jpg", 288, 22.90m, "500 рецепти за бебета и малки деца", 2024 },
                    { 22, "Пергамент Прес", "В този сборник си дават среща изтънченият и понякога циничен хумор на англичаните, закачливият, дяволит и жизнерадостен хумор на шотландците, пиперливият и прям хумор на ирландците и накрая неподправеният и добродушен хумор на уелсците.", 15, "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/f/i/file_577_211.jpg", 320, 19.95m, "Смях от Британските острови", 2013 }
                });

            migrationBuilder.InsertData(
                table: "BookReviews",
                columns: new[] { "Id", "BookId", "Description", "Rate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Книгата ме потопи в суровия и вдъхновяващ свят на дивата природа! Лондон създава невероятно усещане за живот на ръба между цивилизацията и природата, като главният герой Бък става символ на оцеляването и личната еволюция. Препоръчвам на всички любители на приключенски романи и природата.", 10, "Незабравимо приключение!", "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 2, 6, "Току-що приключих с четенето на „Пипи Дългото чорапче“ и не мога да не споделя колко ми хареса! Пипи е една от най-забавните и нестандартни героини, които съм срещала. Нейният уникален характер, свобода на духа и хумор я правят незабравима. Освен това, животът й е изпълнен с толкова невероятни приключения, че няма как да не се увлечеш по нея! Всеки момент с нея е забавен и лек, но същевременно носи и уроци за приятелството, смелостта и стойността на свободата. Книгата е за всички възрасти, но аз лично не можех да спра да се смея на някои от нейните лудории и смели решения. Препоръчвам на всеки, който търси книга, която да му донесе радост и приключения.", 10, "Уникална по рода си книга!", "c4fbe2f71-126f-46c3-af99-8dc035eac772" },
                    { 3, 10, "„Дон Кихот“ е произведение, което ни представя уникална смесица от хумор и трагедия, но не мога да кажа, че веднага ме завладя. Образът на Дон Кихот е интересен, но понякога твърде странен за моите предпочитания. Тази книга изисква внимание и размисъл, но може да не е за всеки читател.", 5, "Велико произведение, но не за всеки вкус.", "b4a1311e-dff4-4c3a-9cf7-b794557bdf80" },
                    { 4, 8, "Честно казано, не успях да се потопя в света на Фондацията и ми беше трудно да се свържа с героите. Смятах, че научната фантастика ще е по-ангажираща, но този роман не успя да задържи вниманието ми. Някои пасажи бяха прекалено дълги и скучни. За съжаление, не беше моето четиво.", 1, "Не, не и НЕ!", "7c8eb412-65a9-4050-8c67-62278f3af93c" },
                    { 5, 2, "Книгата ме изуми с богатството на информация и историческа достоверност. Историята на българския народ, разказана през погледа на Паисий Хилендарски, е не само задълбочена, но и изпълнена със страст и гордост. През всяка страница усещах любовта на автора към Родината и силата на народния дух. Всеки българин трябва да се запознае с това произведение, за да разбере по-добре своето минало и корените на своята идентичност. Препоръчвам я на всички, които искат да се потопят в българската история и да я преживеят отново!", 10, "Задължително четиво за всеки българин!", "b4a1311e-dff4-4c3a-9cf7-b794557bdf80" },
                    { 6, 3, "Книгата беше приятна за четене, но не мога да кажа, че ме впечатли. Историята на Пъжи и неговото пътуване около света е интересна, но не беше толкова динамична, колкото очаквах. Спокойният стил на писане на Жул Верн не успя да ме погълне напълно и се почувствах леко разочарован. Все пак, въпреки че не ми се стори изключителна, не мога да отрека, че е увлекателна и доста класическа приключенска история. Препоръчвам я на тези, които обичат по-лежерни приключения.", 6, "Забавна, но не толкова вълнуваща", "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 7, 4, "История на Херодот е книга, която не просто ме възхити, а напълно промени възприятията ми за историята и човешката цивилизация. За първи път се срещнах с толкова обширно и задълбочено изложение на събития, които преди да прочета, бяха просто мъгляви елементи от учебниците. Херодот е истински майстор на разказа, който умее да потопи читателя в света на древността. Книгата не е просто хронология, тя е пътуване през различни култури и народи, които са оформили съвременната история, както я познаваме. Всеки ред беше наситен с толкова много информация, че ми се искаше да го четем по-бавно, за да усвоя всички детайли. Горещо препоръчвам на всеки, който обича историята и е готов да се потопи в древността.", 10, "Велико произведение, което ще ми остане в сърцето!", "7c8eb412-65a9-4050-8c67-62278f3af93c" },
                    { 8, 5, "Очаквах много повече от тази книга, но за съжаление тя не успя да ме впечатли. Сюжетът ми се стори изключително плосък, а стилът на писане - сух и скучен. За такава важна тема, като историята на изкуството, се изисква много по-задълбочено и ангажиращо представяне. Може би за някои хора тя ще е полезна, но за мен беше разочароваща и не ме вдъхнови да се запозная по-задълбочено с изкуството.", 3, "Не оправда очакванията ми", "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 9, 9, "„Дневникът на Ане Франк“ е изключителен разказ за живота на едно младо момиче, което преживява нечовешки изпитания през Втората световна война. Нейният дневник ме докосна дълбоко, като показва смелостта и надеждата, въпреки ужасите на времето. Писанията й са искрени и пълни с емоция. Историята е толкова лична, но същевременно универсална, и оставя трайни следи в съзнанието. Препоръчвам на всички да я прочетат, защото тя е част от световното културно наследство.", 10, "Силно въздействаща книга!", "7c8eb412-65a9-4050-8c67-62278f3af93c" },
                    { 10, 7, "„Приключенията на Том Сойер“ определено има своите забавни моменти и увлекателни ситуации, но като цяло не се оказа толкова вълнуваща, колкото очаквах. Има забавни сцени, които със сигурност биха заинтригували по-младите читатели, но за мен книгата не предложи нещо изключително в повествованието. Може би е по-интересна за по-млади аудитории, които ще оценят приключенията на Том и Хък ФInn, но за мен остана леко повърхностна.", 6, "Забавна, но не чак толкова впечатляваща", "c4fbe2f71-126f-46c3-af99-8dc035eac772" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_UserId",
                table: "ArticleComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_UserId",
                table: "BookReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksBookStores_BookStoreId",
                table: "BooksBookStores",
                column: "BookStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksCarts_CartId",
                table: "BooksCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksUsersRead_UserId",
                table: "BooksUsersRead",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsCarts_CartId",
                table: "EventsCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsParticipants_ParticipantId",
                table: "EventsParticipants",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_UserId",
                table: "Publishers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCurrentlyReading_UserId",
                table: "UsersCurrentlyReading",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersWantToRead_UserId",
                table: "UsersWantToRead",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookReviews");

            migrationBuilder.DropTable(
                name: "BooksBookStores");

            migrationBuilder.DropTable(
                name: "BooksCarts");

            migrationBuilder.DropTable(
                name: "BooksUsersRead");

            migrationBuilder.DropTable(
                name: "EventsCarts");

            migrationBuilder.DropTable(
                name: "EventsParticipants");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "UsersCurrentlyReading");

            migrationBuilder.DropTable(
                name: "UsersWantToRead");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BookStores");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
