using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace PRN221_PawFundSystem_Group5.Pages.HealthCheckPage
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.PawFundContext _context;

        public CreateModel(BusinessObjects.Models.PawFundContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CheckedBy"] = new SelectList(_context.Users, "Id", "Email");
        ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Id");
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

            _context.HealthChecks.Add(HealthCheck);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
