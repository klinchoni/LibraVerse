using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LibraVerse.Common.EntityValidationConstants.Genre;
namespace LibraVerse.Data.Models.Books
{
    public class Genre
    {
        [Key]
        [Comment("The Genre's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The Genre's Name")]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
