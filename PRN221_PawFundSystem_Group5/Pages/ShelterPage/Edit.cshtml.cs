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

namespace PRN221_PawFundSystem_Group5.Pages.ShelterPage
{
    public class EditModel : PageModel
    {
        private readonly IShelterService _shelterService;
        private readonly IUserService _userService;

        public EditModel(IShelterService shelterService, IUserService userService)
        {
            _shelterService = shelterService;
            _userService = userService;
        }

        [BindProperty]
        public Shelter Shelter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter =  _shelterService.GetShelterById(id);
            if (shelter == null)
            {
                return NotFound();
            }
            Shelter = shelter;
           ViewData["ManagedBy"] = new SelectList(_userService.GetUsers(), "Id", "Email");
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

            bool checkUpdate = _shelterService.UpdateShelter(Shelter);

            return RedirectToPage("./Index");
        }

        private bool ShelterExists(int id)
        {
            return _shelterService.GetShelterById(id) != null;
        }
    }
}
