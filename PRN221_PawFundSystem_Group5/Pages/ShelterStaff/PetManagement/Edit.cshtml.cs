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

namespace PRN221_PawFundSystem_Group5.Pages.ShelterStaff.PetManagement
{
    public class EditModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IShelterService _shelterService;
        private readonly IUserService _userService;
        public EditModel(IPetService petService, IShelterService shelterService, IUserService userService)
        {
            _petService = petService;
            _shelterService = shelterService;
            _userService = userService;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pet = await _petService.GetPetById((int)id);
            if (pet == null)
            {
                return NotFound();
            }
            Pet = pet;
            ViewData["OwnerId"] = new SelectList(_userService.GetUsers(), "Id", "Email");
            ViewData["ShelterId"] = new SelectList(_shelterService.GetShelters(), "Id", "Id");
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

            try
            {
                _petService.UpdatePet(Pet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PetExists(Pet.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> PetExists(int id)
        {
            return await _petService.GetPetById(id) != null;
        }
    }
}
