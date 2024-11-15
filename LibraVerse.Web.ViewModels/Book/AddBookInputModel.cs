namespace LibraVerse.Web.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.EntityValidationConstants.Book;
    using static LibraVerse.Common.EntityValidationMessages.Book;
    public class AddBookInputModel
    {
        public AddBookInputModel()
        {
            this.ReleaseDate = DateTime.UtcNow.ToString(ReleaseDateFormat);
        }
        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreRequiredMessage)]
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ReleaseDateRequiredMessage)]
        public string ReleaseDate { get; set; }

        [Required(ErrorMessage = PagesRequiredMessage)]
        [Range(PagesMinNumber,PagesMaxNumber)]
        public int Pages {  get; set; }

        [Required(ErrorMessage = AuthorRequiredMessage)]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(NameMaxLength)]
        public string Description { get; set; } = null!;
    }
}
