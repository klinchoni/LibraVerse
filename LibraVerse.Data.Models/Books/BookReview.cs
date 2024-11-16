using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static LibraVerse.Common.EntityValidationConstants.BookReview;

namespace LibraVerse.Data.Models.Books
{
    public class BookReview
    {
        [Key]
        [Comment("The Book Review's Identifier")]
        public Guid Id { get; set; }

        [MaxLength(BookReviewTitleMaxLength)]
        [Comment("The Book Review's Title")]
        public string Title { get; set; } = null!;

        [MaxLength(BookReviewDescriptionMaxLength)]
        [Comment("The Book Review's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The Book Review's Rate")]
        public int Rate { get; set; }


        [Required]
        [Comment("The Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The Book")]
        public Book Book { get; set; } = null!;

        [Required]
        [Comment("The User's Identifier")]
        public string UserId { get; set; } = null!;

       // [ForeignKey(nameof(UserId))]
      //  [Comment("The User")]
       // public ApplicationUser User { get; set; } = null!;
    }
}
