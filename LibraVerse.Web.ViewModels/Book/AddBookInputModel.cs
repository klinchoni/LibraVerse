namespace LibraVerse.Web.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.EntityValidationConstants.Book;
    public class AddBookInputModel
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Range(PagesMinNumber,PagesMaxNumber)]
        public int Pages {  get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(NameMaxLength)]
        public string Description { get; set; } = null!;
    }
}
