namespace LibraVerse.Core.Models.QueryModels.BookStore
{
    using LibraVerse.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookStore;
    public class BookStoreServiceModel : IBookStoreModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BookStoreNameMaxLength, MinimumLength = BookStoreNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(BookStoreLocationMaxLength, MinimumLength = BookStoreLocationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Location { get; set; } = null!;

        [Required]
        public DateTime OpeningTime { get; set; }

        [Required]
        public DateTime ClosingTime { get; set; }

        [Required]
        [StringLength(BookStoreImageUrlMaxLength, MinimumLength = BookStoreImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;

        public bool Status { get; set; } = false;
    }
}