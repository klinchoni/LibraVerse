using LibraVerse.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using static LibraVerse.Common.EntityValidationConstants.Book;

namespace LibraVerse.Data.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //Fluent API

           builder.HasKey(b => b.Id);

           builder
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
               .Property(b => b.Author)
               .IsRequired()
               .HasMaxLength(NameMaxLength );

            builder
                .Property(b => b.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLength);

            builder
               .Property(b => b.Pages)
               .IsRequired()
               .HasMaxLength(PagesMaxLength);

            builder.HasData(this.SeedBooks()); // To seed the base 
        }

        private List<Book> SeedBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Title = "Лорд на клановете",
                    Author = "Кристи Голдън",
                    Genre = "Фентъзи",
                    ReleaseDate = new DateTime(2001, 10, 1),
                    Pages = "278"
                },
                new Book()
                {
                    Title = "Българчета",
                    Author = "Ангел Каралийчев",
                    Genre = "Разкази и приказки за деца",
                    ReleaseDate = new DateTime(1942),
                    Pages = "192"
                }
            };
           

            return books;
        }

    }
}
