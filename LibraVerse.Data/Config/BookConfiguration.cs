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
        }
    }
}
