namespace LibraVerse.Data.Models.BookStores
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookStore;
    using LibraVerse.Data.Models.Mappings;
    public class BookStore
    {
        [Comment("The Identifier of the BookStore")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookStoreNameMaxLength)]
        [Comment("The Name of the BookStore")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(BookStoreLocationMaxLength)]
        [Comment("The Location of the BookStore")]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("The Contact of the BookStore")]
        public string Contact { get; set; } = null!;

        [Required]
        [Comment("The Opening Time of the BookStore")]
        public DateTime OpeningTime { get; set; }

        [Required]
        [Comment("The Closing Time of the BookStore")]
        public DateTime ClosingTime { get; set; }

        [Required]
        [MaxLength(BookStoreImageUrlMaxLength)]
        [Comment("The Image Url of the BookStore")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<BookBookStore> BooksBookStores { get; set; } = new HashSet<BookBookStore>();

    }
}
