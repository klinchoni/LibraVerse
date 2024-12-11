namespace LibraVerse.Data.Models.Carts
{
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Data.Models.Mappings;
    using LibraVerse.Data.Models.Roles;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}