namespace LibraVerse.Core.Models.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;

    using LibraVerse.Core.Contracts;

    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Article;

    public class ArticleEditViewModel : IArticleModel
    {
        public int Id { get; set; }

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