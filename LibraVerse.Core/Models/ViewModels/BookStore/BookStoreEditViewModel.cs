namespace LibraVerse.Core.Models.ViewModels.BookStore
{
    using NovelNest.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Data.Constants.DataConstants;
    using static LibraVerse.Data.Constants.DataConstants.BookStoreConstants;

    public class BookStoreEditViewModel : IBookStoreModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BookStoreNameMaxLength, MinimumLength = BookStoreNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(BookStoreLocationMaxLength, MinimumLength = BookStoreLocationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Location { get; set; } = null!;

        [Required]
        [StringLength(BookStoreContactMaxLength, MinimumLength = BookStoreContactMinLength, ErrorMessage = LengthErrorMessage)]
        public string Contact { get; set; } = null!;

        [Required]
        public DateTime OpeningTime { get; set; }

        [Required]
        public DateTime ClosingTime { get; set; }

        [Required]
        [StringLength(BookStoreImageUrlMaxLength, MinimumLength = BookStoreImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}