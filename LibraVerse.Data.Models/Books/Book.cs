namespace LibraVerse.Data.Models.Books
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Book;
    using LibraVerse.Data.Models.Mappings;
    public class Book
    {
        [Key]
        [Comment("The Identifier of the Book")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("The Title of the Book")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("The Author of the Book")]
        public string Author { get; set; } = null!;

        [Required]
        [Comment("The Identifier of the Book Genre")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        [Comment("The Genre of the Book")]
        public Genre Genre { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("The Description of Book")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The Book's Pages Count")]
        public int Pages { get; set; }


        [Required]
        [Comment("The published date on the Book")]
        public int ReleaseDate { get; set; }

        [Required]
        [Comment("The Price of the Book")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("The Book's cover Image Url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<BookBookStore> BooksBookStores { get; set; } = new HashSet<BookBookStore>();
        public ICollection<BookReview> Reviews { get; set; } = new HashSet<BookReview>();
        public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
    }
}
