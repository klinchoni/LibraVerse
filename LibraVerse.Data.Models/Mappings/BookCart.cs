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

        // Добавено свойство Quantity, което ще показва количеството на събитието в количката
        [Required]
        [Comment("The quantity of the book in the cart")]
        public int Quantity { get; set; }

        // Добавено свойство за дата на добавяне на книгата в количката
        [Required]
        [Comment("Date when the book was added to the cart")]
        public DateTime DateAdded { get; set; } = DateTime.Now; // Може да се зададе по подразбиране на текущата дата и час
    }
}