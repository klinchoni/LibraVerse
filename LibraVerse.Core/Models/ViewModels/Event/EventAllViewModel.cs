﻿using LibraVerse.Core.Contracts;

namespace LibraVerse.Core.ViewModels.Event
{
    public class EventAllViewModel : IEventModel
    {
        public int Id { get; set; }
        public string Topic { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}