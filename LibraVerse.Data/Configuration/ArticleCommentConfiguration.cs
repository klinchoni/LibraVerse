namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using LibraVerse.Data.Models.Articles;
    using LibraVerse.Data.Seeding;

    internal class ArticleCommentConfiguration : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            var data = new DataSeed();

            builder.HasData(new ArticleComment[] { data.Comment1, data.Comment2, data.Comment3, data.Comment4, data.Comment5,
                data.Comment6, data.Comment7, data.Comment8, data.Comment9, data.Comment10});
        }
    }
}