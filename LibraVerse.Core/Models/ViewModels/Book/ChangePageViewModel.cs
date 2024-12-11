namespace LibraVerse.Core.Models.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;

    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookCurrentlyReadingConstants;

    public class ChangePageViewModel
    {
        public int BookId { get; set; }
        public string UserId { get; set; } = null!;

        [Range(BookCurrentPageMinRange, int.MaxValue, ErrorMessage = RangeErrorMessage)]
        public int CurrentPage { get; set; }
        public int BookPages { get; set; }
    }
}