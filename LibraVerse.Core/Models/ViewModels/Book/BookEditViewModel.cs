namespace LibraVerse.Core.Models.ViewModels.Book
{
    using LibraVerse.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookConstants;

    public class BookEditViewModel : IBookModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(BookPageMinValue, BookPageMaxValue, ErrorMessage = RangeErrorMessage)]
        public int Pages { get; set; }

        [Required]
        [Range(YearPublishedMinRange, YearPublishedMaxRange, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Year Published")]
        public int YearPublished { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = RangeErrorMessage,
            ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();
    }
}