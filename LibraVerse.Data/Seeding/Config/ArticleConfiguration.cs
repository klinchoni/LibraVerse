﻿namespace LibraVerse.Data.Seeding.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LibraVerse.Data.Models.Articles;

    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Article[]
            {
                data.ArticleOne,
                data.ArticleTwo,
                data.ArticleThree,
                data.ArticleFour,
                data.ArticleFive,
                data.ArticleSix,
                data.ArticleSeven,
                data.ArticleEight,
                data.ArticleNine,
            });
        }
    }
}