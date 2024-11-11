using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Service.IService;
using Service.Service;

namespace PRN221_PawFundSystem_Group5.Pages.VolunteerTaskPage
{
    public class CreateModel : PageModel
    {
        private readonly IVolunteerTaskService _volunteerTaskService;
        private readonly IUserService _userService;

        public CreateModel(IVolunteerTaskService volunteerTaskService)
        {
            _volunteerTaskService= volunteerTaskService;
        }

        public IActionResult OnGet()
        {
        ViewData["AssignedBy"] = new SelectList(_userService.GetUsers(), "Id", "Email");
        ViewData["AssignedTo"] = new SelectList(_userService.GetUsers(), "Id", "Email");
            return Page();
        }

        [BindProperty]
        public VolunteerTask VolunteerTask { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _volunteerTaskService.AddVolunteerTask(VolunteerTask);
            

            return RedirectToPage("./Index");
        }
    }
}
