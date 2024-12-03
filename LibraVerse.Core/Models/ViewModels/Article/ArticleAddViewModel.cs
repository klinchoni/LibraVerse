namespace LibraVerse.Core.Models.ViewModels.Article
{
    using LibraVerse.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Article;
    using static LibraVerse.Common.EntityValidationMessages.Data;

    public class ArticleAddViewModel : IArticleModel
    {
        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ArticleContentMaxLength, MinimumLength = ArticleContentMinLength, ErrorMessage = LengthErrorMessage)]
        public string Content { get; set; } = null!;

        [Required]
        [StringLength(ArticleImageUrlMaxLength, MinimumLength = ArticleImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}