namespace LibraVerse.Data.Models.Mappings
{
    using LibraVerse.Data.Models.Events;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using LibraVerse.Data.Models.Roles;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventParticipant
    {
        [Required]
        [Comment("The current Event's Identifier")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The current Event")]
        public Event Event { get; set; } = null!;


        [Required]
        [Comment("The current Participant's Identifier")]
        public string ParticipantId { get; set; } = null!;

        [ForeignKey(nameof(ParticipantId))]
        [Comment("The current Participant")]
        public ApplicationUser Participant { get; set; } = null!;
    }
}
