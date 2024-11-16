using LibraVerse.Common;
using LibraVerse.Data.Models.Mappings;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LibraVerse.Common.EntityValidationConstants.Book;

namespace LibraVerse.Data.Models.Books
{
    public class Book
    {
        [Key]
        [Comment("The current Book's Identifier")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("The Title of the Book")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("The Author of the Book")]
        public string Author { get; set; } = null!;

        [Required]
        [Comment("The current Book's Genre's Identifier")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        [Comment("The current Book's Genre")]
        public Genre Genre { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("The current Book's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The current Book's Pages Count")]
        public int Pages { get; set; }


        [Required]
        [Comment("The date on which the curent Book was published")]
        public int ReleaseDate { get; set; }

        [Required]
        [Comment("The current Book's Price")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("The current Book's cover image url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<BookBookStore> BooksBookStores { get; set; } = new HashSet<BookBookStore>();
        public ICollection<BookReview> Reviews { get; set; } = new HashSet<BookReview>();
        public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
    }
}
