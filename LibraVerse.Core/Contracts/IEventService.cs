namespace LibraVerse.Core.Contracts
{
    using LibraVerse.Core.Enums;
    using LibraVerse.Core.Models.QueryModels.Event;
    using LibraVerse.Core.Models.ViewModels.Event;
    using LibraVerse.Data.Models.Events;

    public interface IEventService
    {
        Task<EventQueryServiceModel> AllAsync(
            string? searchTerm = null,
            EventSorting sorting = EventSorting.All,
            EventStatus status = EventStatus.All,
            int currentPage = 1,
            int eventsPerPage = 4);

        Task<bool> EventExistsAsync(int eventId);
        Task<Event> FindEventByIdAsync(int eventId);
        Task<EventDetailsViewModel> DetailsAsync(int eventId);
    }
}