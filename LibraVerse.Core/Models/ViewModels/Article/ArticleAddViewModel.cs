namespace LibraVerse.Core.Models.ViewModels.Article
{
    using LibraVerse.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Data.Constants.DataConstants;
    using static LibraVerse.Data.Constants.DataConstants.ArticleConstants;

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