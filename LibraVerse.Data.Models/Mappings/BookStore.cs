using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibraVerse.Data.Models.Books;
using LibraVerse.Data.Models.BookStores;

namespace LibraVerse.Data.Models.Mappings
{
    public class BookBookStore
    {
        [Required]
        [Comment("The current Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The current Book")]
        public Book Book { get; set; } = null!;


        [Required]
        [Comment("The current BookStore's Identifier")]
        public int BookStoreId { get; set; }

        [ForeignKey(nameof(BookStoreId))]
        [Comment("The current BookStore")]
        public BookStore BookStore { get; set; } = null!;
    }
}
