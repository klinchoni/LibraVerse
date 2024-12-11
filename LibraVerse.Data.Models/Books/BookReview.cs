namespace LibraVerse.Data.Models.Books
{
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Data.Models.Roles;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static LibraVerse.Common.Constants.EntityValidationConstants.BookReview;

    public class BookReview
    {
        [Key]
        [Comment("The current Book Review's Identifier")]
        public int Id { get; set; }

        [MaxLength(BookReviewTitleMaxLength)]
        [Comment("The current Book Review's Title")]
        public string Title { get; set; } = null!;

        [MaxLength(BookReviewDescriptionMaxLength)]
        [Comment("The current Book Review's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The current Book Review's Rate")]
        public int Rate { get; set; }


        [Required]
        [Comment("The current Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The current Book")]
        public Book Book { get; set; } = null!;

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public ApplicationUser User { get; set; } = null!;
    }
}