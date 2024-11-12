using LibraVerse.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraVerse.Data.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
           builder.HasKey(b => b.Id);
           builder.Property(b => b.Title).IsRequired().HasMaxLength();
        }
    }
}
