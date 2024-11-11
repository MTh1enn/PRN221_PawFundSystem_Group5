using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.ShelterPage
{
    public class CreateModel : PageModel
    {
        private readonly IShelterService _shelterService;
        private readonly IUserService _userService; 

        public CreateModel(IShelterService shelterService, IUserService userService)
        {
            _shelterService = shelterService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
        ViewData["ManagedBy"] = new SelectList(_userService.GetUsers(), "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Shelter Shelter { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _shelterService.AddShelter(Shelter);

            return RedirectToPage("./Index");
        }
    }
}
