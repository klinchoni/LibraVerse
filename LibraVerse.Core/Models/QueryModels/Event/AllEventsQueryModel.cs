namespace LibraVerse.Core.Models.QueryModels.Event
{
    using System.ComponentModel.DataAnnotations;

    using LibraVerse.Core.Enums;

    public class AllEventsQueryModel
    {
        public int EventsPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public EventSorting Sorting { get; set; }

        [Display(Name = "Статус")]
        public EventStatus Status { get; set; }

        public int TotalEventsCount { get; set; }
        public int CurrentPage { get; set; } = 1;

        public IEnumerable<EventServiceModel> Events { get; set; } = new HashSet<EventServiceModel>();
    }
}
