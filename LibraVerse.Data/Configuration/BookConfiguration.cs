namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Seeding;

    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Book[]
            {
                data.Book1,
                data.Book2,
                data.Book3,
                data.Book4,
                data.Book5,
                data.Book6,
                data.Book7,
                data.Book8,
                data.Book9,
                data.Book10,
                data.Book11,
                data.Book12,
                data.Book13,
                data.Book14,
                data.Book15,
                data.Book16,
                data.Book17,
                data.Book18,
                data.Book19,
                data.Book20,
                data.Book21,
                data.Book22,
            });
        }
    }
}