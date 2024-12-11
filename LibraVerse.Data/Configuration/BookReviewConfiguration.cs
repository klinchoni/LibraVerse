namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Seeding;

    internal class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
    {
        public void Configure(EntityTypeBuilder<BookReview> builder)
        {
            var data = new DataSeed();


            builder.HasData(new BookReview[] { data.FirstReview, data.SecondReview, data.ThirdReview, data.FourthReview,
            data.FifthReview, data.SixthReview, data.SeventhReview, data.EighthReview, data.NinthReview, data.TenthReview});
        }
    }
}