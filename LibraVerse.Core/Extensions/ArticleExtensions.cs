﻿namespace LibraVerse.Core.Extensions
{
    using LibraVerse.Core.Contracts;

    public static class ArticleExtensions
    {
        public static string GetArticleInformation(this IArticleModel book)
        {
            return book.Title.Replace(" ", "-");
        }
    }
}
