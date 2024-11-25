namespace LibraVerse.Data.Models.Roles
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Publisher
    {
        [Key]
        [Comment("The Identifier of the Publisher")]
        public int Id { get; set; }

        [Required]
        [Comment("The Identifier of the User")]
        public string UserId { get; set; } 

        [ForeignKey(nameof(UserId))]
        [Comment("The User")]
        public ApplicationUser User { get; set; } = null!;
    }
}
