using LibraVerse.Data.Models.Carts;
using LibraVerse.Data.Models.Events;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LibraVerse.Data.Models.Mappings
{
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
    }
}
