﻿namespace LibraVerse.Data.Models.BookUserActions
{

    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.Roles;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BookUserRead
    {
        [Required]
        [Comment("The current Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The current Book")]
        public Book Book { get; set; } = null!;


        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("The time when the entity was added")]
        public DateTime TimeAdded { get; set; }
    }
}
