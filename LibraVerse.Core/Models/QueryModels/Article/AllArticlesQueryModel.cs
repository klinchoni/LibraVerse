﻿namespace LibraVerse.Core.Models.QueryModels.Article
{
    using LibraVerse.Core.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AllArticlesQueryModel
    {
        public int ArticlesPerPage { get; } = 6;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public ArticleSorting Sorting { get; set; }

        public int TotalArticlesCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<ArticleServiceModel> Articles { get; set; } = new HashSet<ArticleServiceModel>();
    }
}