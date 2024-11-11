using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.HealthCheckPage
{
    public class CreateModel : PageModel
    {
        private readonly IHealthCheckService _healthCheckService;
        private readonly IPetService _petService;
        private readonly IUserService _userService;

        public CreateModel(IHealthCheckService healthCheckService, IUserService userService, IPetService petService)
        {
            _healthCheckService = healthCheckService;
            _userService = userService;
            _petService=petService;
        }

        public IActionResult OnGet()
        {
        ViewData["CheckedBy"] = new SelectList(_userService.GetUsers(), "Id", "Email");
        ViewData["PetId"] = new SelectList(_petService.GetAllPets(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public HealthCheck HealthCheck { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _healthCheckService.AddHealthCheck(HealthCheck);
            return RedirectToPage("./Index");
        }
    }
}
