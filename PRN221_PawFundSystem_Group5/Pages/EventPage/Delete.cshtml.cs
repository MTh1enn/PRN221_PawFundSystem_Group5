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
    public class DeleteModel : PageModel
    {
        private readonly IEventService _eventService;

        public DeleteModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public string? Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _eventService.GetEvents() == null)
            {
                return NotFound();
            }

            var events = _eventService.GetEventById(id);

            if (events == null)
            {
                return NotFound();
            }
            else
            {
                Event = events;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = _eventService.GetEventById(id);
            if (events != null)
            {
                Event = events;
                bool checkDelete =_eventService.RemoveEvent(events);
                if(checkDelete == false)
                {
                    Message = "You can't delete event COMPLETED or CANCELLED";
                    return Page();
                }
            }
           

            return RedirectToPage("./Index");
        }
    }
}
