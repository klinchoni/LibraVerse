namespace LibraVerse.Data.Models.Articles
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.Constants.EntityValidationConstants.ArticleComment;
    using LibraVerse.Data.Models.Roles;
    public class ArticleComment
    {
        [Key]
        [Comment("The Identifier of Article Comment")]
        public int Id { get; set; }

        [MaxLength(ArticleCommentTitleMaxLength)]
        [Comment("The Article Comment's Title")]
        public string Title { get; set; } = null!;

        [MaxLength(ArticleCommentDescriptionMaxLength)]
        [Comment("The Article Comment's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The Article's Identifier")]
        public int ArticleId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [Comment("The Article")]
        public Article Article { get; set; } = null!;

        [Required]
        [Comment("The Identifier of the User")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The User")]
        public ApplicationUser User { get; set; } = null!;
    }
}
