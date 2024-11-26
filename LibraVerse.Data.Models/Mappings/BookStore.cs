namespace LibraVerse.Data.Models.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.BookStores;
    public class BookBookStore
    {
        [Required]
        [Comment("The Identifier of the Book")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The Book")]
        public Book Book { get; set; } = null!;


        [Required]
        [Comment("The Identifier of the BookStore")]
        public int BookStoreId { get; set; }

        [ForeignKey(nameof(BookStoreId))]
        [Comment("The BookStore")]
        public BookStore BookStore { get; set; } = null!;
    }
}
