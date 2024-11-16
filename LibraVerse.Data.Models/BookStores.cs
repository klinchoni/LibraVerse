using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LibraVerse.Common.EntityValidationConstants.BookStores;

namespace LibraVerse.Data.Models
{
    public class BookStores
    {
        [Comment("The BookStore's Identifier")]
        public Guid Id { get; set; }
    
        [Required]
        [MaxLength(BookStoreNameMaxLength)]
        [Comment("The BookStore's Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(BookStoreLocationMaxLength)]
        [Comment("The BookStore's Location")]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("The BookStore's Mobile Contact")]
        public string Contact { get; set; } = null!;

        [Required]
        [Comment("The BookStore's Opening Time")]
        public DateTime OpeningTime { get; set; }

        [Required]
        [Comment("The BookStore's Closing Time")]
        public DateTime ClosingTime { get; set; }

        [Required]
        [MaxLength(BookStoreImageUrlMaxLength)]
        [Comment("The BookStore's Image Url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<BookBookStore> BooksBookStores { get; set; } = new HashSet<BookBookStore>();

    }
}
