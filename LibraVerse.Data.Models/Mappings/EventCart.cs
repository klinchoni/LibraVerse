namespace LibraVerse.Data.Models.Mappings
{
    using LibraVerse.Data.Models.Carts;
    using LibraVerse.Data.Models.Events;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class EventCart
    {
        [Required]
        [Comment("The Identifier of the Event")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The Event")]
        public Event Event { get; set; } = null!;

        [Required]
        [Comment("The Identifier of the Cart")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        [Comment("The Cart")]
        public Cart Cart { get; set; } = null!;
    }
}
