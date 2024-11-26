namespace LibraVerse.Data.Models.Carts
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using LibraVerse.Data.Models.Mappings;
    using LibraVerse.Data.Models.Roles;

    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("The Identifier of the User")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The User")]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}
