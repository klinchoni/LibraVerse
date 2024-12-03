namespace LibraVerse.Data.Models.BookUser
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.Roles;

    public class UserRead
    {
        [Required]
        [Comment("The Identifier of the Book")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The Book")]
        public Book Book { get; set; } = null!;


        [Required]
        [Comment("The Identifier of the User")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The User")]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("The time when the entity was added")]
        public DateTime TimeAdded { get; set; }
    }
}
