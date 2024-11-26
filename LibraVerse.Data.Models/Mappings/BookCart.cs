namespace LibraVerse.Data.Models.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.Carts;
    public class BookCart
    {
        [Required]
        [Comment("The Identifier of the Book")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The Book")]
        public Book Book { get; set; } = null!;

        [Required]
        [Comment("The Identifier of the Cart")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        [Comment("The Cart")]
        public Cart Cart { get; set; } = null!;
    }
}
