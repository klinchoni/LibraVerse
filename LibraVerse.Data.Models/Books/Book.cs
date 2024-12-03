namespace LibraVerse.Data.Models.Books
{
    using Microsoft.EntityFrameworkCore;
    using LibraVerse.Data.Models.Mappings;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookConstants;
    using System;

    public class Book
    {
        [Key]
        [Comment("The current Book's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("The current Book's Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("The current Book's Author")]
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
        public int YearPublished { get; set; }

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
        public DateTime DateAdded { get; set; }
    }
}