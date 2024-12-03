namespace LibraVerse.Data.Models.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using LibraVerse.Data.Models.Carts;
    using LibraVerse.Data.Models.Events;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventCart
    {
        [Required]
        [Comment("The current Event's Identifier")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The current Event")]
        public Event Event { get; set; } = null!;

        [Required]
        [Comment("The current Cart's Identifier")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        [Comment("The current Cart")]
        public Cart Cart { get; set; } = null!;

        // Добавено свойство Quantity, което ще показва количеството на събитието в количката
        [Required]
        [Comment("The quantity of the event in the cart")]
        public int Quantity { get; set; }

        // Добавено свойство за дата на добавяне на събитието в количката
        [Required]
        [Comment("Date when the event was added to the cart")]
        public DateTime DateAdded { get; set; } = DateTime.Now; // Може да се зададе по подразбиране на текущата дата и час
    }
}

