﻿namespace LibraVerse.Core.Models.ViewModels.Event
{
    using LibraVerse.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Data.Constants.DataConstants;
    using static LibraVerse.Data.Constants.DataConstants.EventConstants;

    public class EventAddViewModel : IEventModel
    {
        [Required]
        [StringLength(EventTopicMaxLength, MinimumLength = EventTopicMinLength, ErrorMessage = LengthErrorMessage)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(EventLocationMaxLength, MinimumLength = EventLocationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Location { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(EventSeatsMinRange, EventSeatsMaxRange)]
        public int Seats { get; set; }

        [Required]
        [Range(EventTicketPriceMinRange, EventTicketPriceMaxRange)]
        public decimal TicketPrice { get; set; }

        [Required]
        [StringLength(EventImageUrlMaxLength, MinimumLength = EventImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}