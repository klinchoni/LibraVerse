namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using LibraVerse.Data.Models.Articles;
    using LibraVerse.Data.Seeding;

    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Article[]
            {
                data.Article1,
                data.Article2,
                data.Article3,
                data.Article4,
                data.Article5,
                data.Article6,
                data.Article7,
                data.Article8,
                data.Article9,
                data.Article10,
            });
        }
    }
}