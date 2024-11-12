using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LibraVerse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraVerse.Data
{
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
