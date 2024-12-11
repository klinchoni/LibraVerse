namespace LibraVerse.Core.Models.QueryModels.Book
{
    using System.ComponentModel.DataAnnotations;

    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookReview;
    public class BookReviewServiceModel
    {
        public int Id { get; set; }

        [StringLength(BookReviewTitleMaxLength, MinimumLength = BookReviewTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string? Title { get; set; } = null!;

        [StringLength(BookReviewDescriptionMaxLength, MinimumLength = BookReviewDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string? Description { get; set; }

        [Required]
        [Range(BookReviewRateMinRange, BookReviewRateMaxRange, ErrorMessage = RangeErrorMessage)]
        public int Rate { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}