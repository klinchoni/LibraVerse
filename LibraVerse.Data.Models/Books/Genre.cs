namespace LibraVerse.Data.Models.Books
{
    using Microsoft.EntityFrameworkCore;

    using System.ComponentModel.DataAnnotations;

    using static LibraVerse.Common.Constants.EntityValidationConstants.Genre;

    public class Genre
    {
        [Key]
        [Comment("The current Genre's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The current Genre's Name")]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}