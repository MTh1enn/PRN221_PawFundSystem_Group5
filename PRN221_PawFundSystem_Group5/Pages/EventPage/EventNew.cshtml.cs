using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.EventPage
{
    public class EventNewModel : PageModel
    {
        private readonly IEventService _eventService;

        public EventNewModel(IEventService eventService)
        {
            _eventService = eventService;
        }
        public IList<Event> Event { get; set; } = default!;
        public int PageSize { get; set; } = 4;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        public IActionResult OnGet(int? pageIndex)
        {
            var allEvent = _eventService.GetEvents();
            CurrentPage = pageIndex ?? 1;

            TotalPages = (int)Math.Ceiling((double)allEvent.Count / PageSize);
            Event = allEvent

           .Skip((CurrentPage - 1) * PageSize)
           .Take(PageSize)
           .ToList();

            return Page();
        }
    }
}
