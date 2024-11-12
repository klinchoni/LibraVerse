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
               .Property(b => b.Description)
               .IsRequired()
               .HasMaxLength(DescriptionMaxLength);

            builder.HasData(this.SeedBooks()); // To seed the base 
        }

        private List<Book> SeedBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Title = "Lord of the Clans",
                    Author = "Christie Golden",
                    Genre = "Fantasy",
                    ReleaseDate = new DateTime(2001, 10, 1),
                    Description = "Raised from infancy by cruel human masters who sought to mold him into their perfect pawn, Thrall was driven by both the savagery in his heart and the cunning of his upbringing to pursue a destiny he was only beginning to understand to break his bondage and rediscover the ancient traditions of his people."
                },
                new Book()
                {
                    Title = "Bulgarcheta",
                    Author = "Angel Karaliichev",
                    Genre = "Fairy tales",
                    ReleaseDate = new DateTime(1942),
                    Description = "The collection from 1942, Bulgarcheta introduces us to the magical world of Karaliychev. Some of the stories included are set in magical and fairy-tale lands, while others are instructive tales from his time. The combination of the wisdom of folk proverbs and the author's artistic talent make the book a read that will not fail to be enjoyed by young readers."
                }

            };

            return books;
        }

    }
}
