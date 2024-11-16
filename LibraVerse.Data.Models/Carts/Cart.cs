using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibraVerse.Data.Models.Mappings;
using LibraVerse.Data.Models.Roles;

namespace LibraVerse.Data.Models.Carts
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("The User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}
