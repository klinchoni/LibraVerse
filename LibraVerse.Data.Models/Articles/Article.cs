namespace LibraVerse.Data.Models.Articles
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Article;
    public class Article
    {
        [Key]
        [Comment("The Identifier of Article")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleTitleMaxLength)]
        [Comment("The Article's Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ArticleContentMaxLength)]
        [Comment("The Article's Content")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("The posted date on the Article")]
        public DateTime DatePublished { get; set; }

        [Required]
        [MaxLength(ArticleImageUrlMaxLength)]
        [Comment("The Article's Image Url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("The Article's Views Count")]
        public int ViewsCount { get; set; }

        public ICollection<ArticleComment> Comments { get; set; } = new HashSet<ArticleComment>();
    }
}
