namespace LibraVerse.Core.Models.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.ArticleComment;
    public class ArticleCommentAddViewModel
    {
        [Required]
        [StringLength(ArticleCommentTitleMaxLength, MinimumLength = ArticleCommentTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ArticleCommentDescriptionMaxLength, MinimumLength = ArticleCommentDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}