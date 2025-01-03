﻿namespace LibraVerse.Data.Models.Roles
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Publisher
    {
        [Key]
        [Comment("The current Publisher's Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public ApplicationUser User { get; set; } = null!;
    }
}