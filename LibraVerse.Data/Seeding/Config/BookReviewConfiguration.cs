namespace LibraVerse.Data.Seeding.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LibraVerse.Data.Models.Books;

    internal class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
    {
        public void Configure(EntityTypeBuilder<BookReview> builder)
        {
            var data = new DataSeed();

            builder.HasData(new BookReview[] { data.ReviewOne, data.ReviewTwo, data.ReviewThree, data.ReviewFour });
        }
    }
}