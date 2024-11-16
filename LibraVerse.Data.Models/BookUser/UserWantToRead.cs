﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraVerse.Data.Models.BookUser
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.Roles;

    public class UserWantToRead
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