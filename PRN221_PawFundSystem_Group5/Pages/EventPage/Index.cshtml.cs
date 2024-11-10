using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service.IService;

namespace PawFundSystem.Page.EventPage
{
    public class IndexModel : PageModel
    {
        private readonly IEventService _eventService;

        public IndexModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IList<Event> Event { get;set; } = default!;
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
