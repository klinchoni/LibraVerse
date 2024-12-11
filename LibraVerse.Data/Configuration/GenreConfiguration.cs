namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Seeding;

    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Genre[]
            {
                  data.Adventure,
                  data.Art,
                  data.Autobiography,
                  data.Business,
                  data.Children,
                  data.ClassicLiterature,
                  data.Cooking,
                  data.Crime,
                  data.Drama,
                  data.Fantasy,
                  data.Fiction,
                  data.Historiography,
                  data.History,
                  data.Horror,
                  data.Humor,
                  data.Military,
                  data.Music,
                  data.Mythology,
                  data.Philosophy,
                  data.Poetry,
                  data.Political,
                  data.Romance,
                  data.Satire,
                  data.Science,
                  data.ScienceFiction,
                  data.ShortStories,
                  data.Thriller
            });
        }
    }
}