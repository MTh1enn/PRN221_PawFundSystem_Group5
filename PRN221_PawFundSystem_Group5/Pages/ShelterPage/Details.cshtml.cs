using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.ShelterPage
{
    public class DetailsModel : PageModel
    {
        private readonly IShelterService _shelterService;

        public DetailsModel(IShelterService shelterService)
        {
            _shelterService = shelterService;
        }

        public Shelter Shelter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = _shelterService.GetShelterById(id);
            if (shelter == null)
            {
                return NotFound();
            }
            else
            {
                Shelter = shelter;
            }
            return Page();
        }
    }
}
