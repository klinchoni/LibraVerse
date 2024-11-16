namespace LibraVerse.Core.Models.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Data.Constants.DataConstants.GenreConstants;

    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}