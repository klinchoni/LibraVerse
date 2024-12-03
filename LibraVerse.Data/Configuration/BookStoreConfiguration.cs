namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LibraVerse.Data.Models.BookStores;
    using LibraVerse.Data.Seeding;

    internal class BookStoreConfiguration : IEntityTypeConfiguration<BookStore>
    {
        public void Configure(EntityTypeBuilder<BookStore> builder)
        {
            var data = new DataSeed();

            builder.HasData(new BookStore[]
            {
                data.BookStore1,
                data.BookStore2,
                data.BookStore3,
                data.BookStore4,
                data.BookStore5,
                data.BookStore6,
                data.BookStore7,
                data.BookStore8,
                data.BookStore9,
                data.BookStore10,
                data.BookStore11,
                data.BookStore12,
                data.BookStore13,
                data.BookStore14,
                data.BookStore15,
            });
        }
    }
}