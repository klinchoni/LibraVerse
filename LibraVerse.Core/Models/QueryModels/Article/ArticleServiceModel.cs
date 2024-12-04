namespace LibraVerse.Core.Models.QueryModels.Article
{
    using LibraVerse.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Article;

    public class ArticleServiceModel : IArticleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(ArticleViewsCountMinRange, uint.MaxValue, ErrorMessage = RangeErrorMessage)]
        public int ViewsCount { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required]
        [StringLength(ArticleImageUrlMaxLength, MinimumLength = ArticleImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}