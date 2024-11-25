namespace LibraVerse.Data.Models.Books
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookReview;
    using LibraVerse.Data.Models.Roles;
    public class BookReview
    {
        [Key]
        [Comment("The Identifier of the Book Review")]
        public int Id { get; set; }

        [MaxLength(BookReviewTitleMaxLength)]
        [Comment("The Title of the Book Review")]
        public string Title { get; set; } = null!;

        [MaxLength(BookReviewDescriptionMaxLength)]
        [Comment("The Description of the Book Review")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The Book Review's Rate")]
        public int Rate { get; set; }


        [Required]
        [Comment("The Idetifier of the Book")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The Book")]
        public Book Book { get; set; } = null!;

        [Required]
        [Comment("The Identifier of the Book")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The User")]
         public ApplicationUser User { get; set; } = null!;
    }
}
