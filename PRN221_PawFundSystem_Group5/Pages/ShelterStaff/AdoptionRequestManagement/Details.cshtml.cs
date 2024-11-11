using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.ShelterStaff.AdoptionRequestManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IAdoptionRequestService _adoptionRequestService;

        public DetailsModel(IAdoptionRequestService adoptionRequestService)
        {
            _adoptionRequestService = adoptionRequestService;
        }

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
            else
            {
                AdoptionRequest = adoptionrequest;
            }
            return Page();
        }
    }
}
