﻿namespace LibraVerse.Core.Models.ViewModels.Event
{
    using System.ComponentModel.DataAnnotations;

    using LibraVerse.Core.Contracts;

    using static LibraVerse.Common.EntityValidationMessages.Data;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Event;

    public class EventEditViewModel : IEventModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(EventTopicMaxLength, MinimumLength = EventTopicMinLength, ErrorMessage = LengthErrorMessage)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(EventLocationMaxLength, MinimumLength = EventLocationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Location { get; set; } = null!;

        public DateTime StartDate { get; set; }

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