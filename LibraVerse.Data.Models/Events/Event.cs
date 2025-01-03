﻿namespace LibraVerse.Data.Models.Events
{
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Data.Models.Mappings;
    using System.ComponentModel.DataAnnotations;

    using static LibraVerse.Common.Constants.EntityValidationConstants.Event;

    public class Event
    {
        [Key]
        [Comment("The current Event's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventTopicMaxLength)]
        [Comment("The current Event's Topic")]
        public string Topic { get; set; } = null!;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        [Comment("The current Event's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(EventLocationMaxLength)]
        [Comment("The current Event's Location")]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("The current Event's start date and hour")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("The current Event's end date and hour")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("The current Event's seats")]
        public int Seats { get; set; }

        [Required]
        [Comment("The current Event's Ticket Price")]
        public decimal TicketPrice { get; set; } = 10;

        [Required]
        [MaxLength(EventImageUrlMaxLength)]
        [Comment("The current Event's Image Url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();
        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}