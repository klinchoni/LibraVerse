namespace LibraVerse.Data
{
    using System.Reflection;
    using LibraVerse.Data.Models.Books;
    using Microsoft.EntityFrameworkCore;
    public class LibraDbContext : DbContext
    {
        //Empty ctor to use it for tests
        public LibraDbContext()
        {
            
        }

        public LibraDbContext(DbContextOptions options)
            :base (options)
        {
            
        }
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
