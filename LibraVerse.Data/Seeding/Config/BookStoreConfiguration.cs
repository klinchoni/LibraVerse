namespace LibraVerse.Data.Seeding.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LibraVerse.Data.Models.BookStores;

    internal class BookStoreConfiguration : IEntityTypeConfiguration<BookStore>
    {
        public void Configure(EntityTypeBuilder<BookStore> builder)
        {
            var data = new DataSeed();

            builder.HasData(new BookStore[]
            {
                data.BookStoreOne,
                data.BookStoreTwo,
                data.BookStoreThree,
                data.BookStoreFour,
                data.BookStoreFive,
                data.BookStoreSix,
                data.BookStoreSeven,
                data.BookStoreEight,
                data.BookStoreNine,
            });
        }
    }
}