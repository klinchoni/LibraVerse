namespace LibraVerse.Data.Models.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LibraVerse.Data.Models.Events;
    using LibraVerse.Data.Models.Roles;

    public class EventParticipant
    {
        [Required]
        [Comment("The Identifier of the Event")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The Event")]
        public Event Event { get; set; } = null!;


        [Required]
        [Comment("The Identifier of the Participant")]
        public string ParticipantId { get; set; } = null!;

        [ForeignKey(nameof(ParticipantId))]
        [Comment("The Participant")]
        public ApplicationUser Participant { get; set; } = null!;
    }
}
