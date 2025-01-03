﻿using LibraVerse.Core.Contracts;

namespace LibraVerse.Core.Models.ViewModels.Article
{
    public class ArticleViewModel : IArticleModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime DatePublished { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int ViewsCount { get; set; }
    }
}