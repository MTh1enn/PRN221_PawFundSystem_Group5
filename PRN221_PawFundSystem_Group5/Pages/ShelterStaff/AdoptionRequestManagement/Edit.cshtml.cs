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
using Service.Service;

namespace PRN221_PawFundSystem_Group5.Pages.ShelterStaff.AdoptionRequestManagement
{
    public class EditModel : PageModel
    {
        private readonly IAdoptionRequestService _adoptionRequestService;
        private readonly IPetService _petService;
        private readonly IUserService _userService;
        public EditModel(IAdoptionRequestService adoptionRequestService, IPetService petService, IUserService userService)
        {
            _adoptionRequestService = adoptionRequestService;
            _petService = petService;
            _userService = userService;
        }

        [BindProperty]
        public AdoptionRequest AdoptionRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionrequest = await _adoptionRequestService.GetById((int)id);
            if (adoptionrequest == null)
            {
                return NotFound();
            }
            AdoptionRequest = adoptionrequest;
            var user = _userService.GetUsers();
            ViewData["PetId"] = new SelectList(await _petService.GetAllPetsAsync(), "Id", "Id");
            ViewData["ReviewedBy"] = new SelectList(user, "Id", "Email");
            ViewData["UserId"] = new SelectList(user, "Id", "Email");
            var statusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "APPROVED", Text = "APPROVED" },
                new SelectListItem { Value = "REJECTED", Text = "REJECTED" }
            };
            ViewData["Status"] = statusList;
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
                int userId = (int)HttpContext.Session.GetInt32("UserId");
                AdoptionRequest.ReviewedBy = userId;
                _adoptionRequestService.Update(AdoptionRequest);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AdoptionRequestExists(AdoptionRequest.Id))
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

        private async Task<bool> AdoptionRequestExists(int id)
        {
            return await _adoptionRequestService.GetById((int)id) != null;
        }
    }
}
