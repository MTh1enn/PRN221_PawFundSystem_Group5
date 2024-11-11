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
            var statusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "SCHEDULED", Text = "SCHEDULED" },
                new SelectListItem { Value = "COMPLETED", Text = "COMPLETED" }
            };
            ViewData["StatusList"] = statusList;
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

            var currentEvent = _eventService.GetEventById(Event.Id);
            if (currentEvent != null && currentEvent.Status == "COMPLETED" && currentEvent.Status == "CANCELLED")
            {
                ModelState.AddModelError(string.Empty, "You cannot update an event that is already COMPLETED OR CANCELLED.");
                ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Email");
                ViewData["StatusList"] = new List<SelectListItem>
                {
                new SelectListItem { Value = "SCHEDULED", Text = "SCHEDULED" },
                new SelectListItem { Value = "COMPLETED", Text = "COMPLETED" }
                };
                return Page();
            }

            bool checkUpdate = _eventService.UpdateEvent(Event);
            return RedirectToPage("./Index");
        }

        private bool EventExists(int id)
        {
            return _eventService.GetEventById(id) != null;
        }
    }
}
