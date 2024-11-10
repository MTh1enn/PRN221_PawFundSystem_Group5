using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service.IService;

namespace PawFundSystem.Page.EventPage
{
    public class EditModel : PageModel
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public EditModel(IEventService eventService, IUserService userService)

        {
            _eventService = eventService;
            _userService = userService;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = _eventService.GetEventById(id);
            if (events == null)
            {
                return NotFound();
            }
            Event = events;
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _eventService.UpdateEvent(Event);
            return RedirectToPage("./Index");
        }

        private bool EventExists(int id)
        {
            return _eventService.GetEventById(id) != null;
        }
    }
}
