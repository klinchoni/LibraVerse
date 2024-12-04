namespace LibraVerse.Data.Models.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.Carts;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BookCart
    {
        [Required]
        [Comment("The current Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The current Book")]
        public Book Book { get; set; } = null!;

        [Required]
        [Comment("The current Cart's Identifier")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        [Comment("The current Cart")]
        public Cart Cart { get; set; } = null!;
    }
}