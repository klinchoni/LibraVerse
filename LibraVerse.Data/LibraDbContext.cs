namespace LibraVerse.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Data.Configuration;
    using LibraVerse.Data.Models.Articles;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.BookUserActions;
    using LibraVerse.Data.Models.BookStores;
    using LibraVerse.Data.Models.Carts;
    using LibraVerse.Data.Models.Events;
    using LibraVerse.Data.Models.Mappings;
    using LibraVerse.Data.Models.Roles;

    public class LibraDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraDbContext(DbContextOptions<LibraDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BookReview> BookReviews { get; set; } = null!;
        public DbSet<BookUserWantToRead> BooksUsersWantToRead { get; set; } = null!;
        public DbSet<BookUserCurrentlyReading> BooksUsersCurrentlyReading { get; set; } = null!;
        public DbSet<BookUserRead> BooksUsersRead { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<BookStore> BookStores { get; set; } = null!;
        public DbSet<BookBookStore> BooksBookStores { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<ArticleComment> ArticleComments { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<BookCart> BooksCarts { get; set; } = null!;
        public DbSet<EventCart> EventsCarts { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookBookStore>()
                .HasKey(bbs => new { bbs.BookId, bbs.BookStoreId });

            builder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.EventId, ep.ParticipantId });

            builder.Entity<BookUserWantToRead>()
                .HasKey(buwr => new { buwr.BookId, buwr.UserId });

            builder.Entity<BookUserCurrentlyReading>()
                .HasKey(bucr => new { bucr.BookId, bucr.UserId });

            builder.Entity<BookUserRead>()
                .HasKey(bur => new { bur.BookId, bur.UserId });

            builder.Entity<BookCart>()
                .HasKey(bc => new { bc.BookId, bc.CartId });

            builder.Entity<EventCart>()
                .HasKey(bc => new { bc.EventId, bc.CartId });

            builder.Entity<Book>()
                .Property(b => b.Price)
            .HasPrecision(18, 2);

            builder.Entity<Event>()
                .Property(b => b.TicketPrice)
            .HasPrecision(18, 2);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());
            builder.ApplyConfiguration(new PublisherConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new BookReviewConfiguration());
            builder.ApplyConfiguration(new BookStoreConfiguration());
            builder.ApplyConfiguration(new ArticleConfiguration());
            builder.ApplyConfiguration(new ArticleCommentConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());

            base.OnModelCreating(builder);
        }
    }
}