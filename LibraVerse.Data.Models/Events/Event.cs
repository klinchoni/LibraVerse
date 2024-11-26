namespace LibraVerse.Data.Models.Events
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Event;
    using LibraVerse.Data.Models.Mappings;
    public class Event
    {
        [Key]
        [Comment("The Identifier of the Event")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventTopicMaxLength)]
        [Comment("The Topic of the Event")]
        public string Topic { get; set; } = null!;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        [Comment("The Description of the Event")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(EventLocationMaxLength)]
        [Comment("The Location of the Event")]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("The start date and start hour of the Event")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("The end date and the end hour of the Event")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("The seats of the Event")]
        public int Seats { get; set; }

        [Required]
        [Comment("The Price of the Ticet on the Event")]
        public decimal TicketPrice { get; set; } = 10;

        [Required]
        [MaxLength(EventImageUrlMaxLength)]
        [Comment("The Image Url of the Event")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();
        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}