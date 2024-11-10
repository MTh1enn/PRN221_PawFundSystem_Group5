using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Service.IService;

namespace PawFundSystem.Page.EventPage
{
    public class CreateModel : PageModel
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public CreateModel(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _eventService.AddEvent(Event);
    
            return RedirectToPage("./Index");
        }
    }
}
