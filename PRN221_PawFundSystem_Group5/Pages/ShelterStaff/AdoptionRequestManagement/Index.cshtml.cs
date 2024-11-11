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
    public class IndexModel : PageModel
    {
        private readonly IAdoptionRequestService _adoptionRequestService;

        public IndexModel(IAdoptionRequestService adoptionRequestService)
        {
            _adoptionRequestService = adoptionRequestService;
        }

        public IList<AdoptionRequest> AdoptionRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AdoptionRequest = await _adoptionRequestService.GetAll();
        }
    }
}
