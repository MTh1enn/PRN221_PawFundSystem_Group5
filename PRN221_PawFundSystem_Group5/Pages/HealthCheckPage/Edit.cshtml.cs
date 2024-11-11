using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_PawFundSystem_Group5.Pages.HealthCheckPage
{
    public class EditModel : PageModel
    {
        private readonly BusinessObjects.Models.PawFundContext _context;

        public EditModel(BusinessObjects.Models.PawFundContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HealthCheck HealthCheck { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthcheck =  await _context.HealthChecks.FirstOrDefaultAsync(m => m.Id == id);
            if (healthcheck == null)
            {
                return NotFound();
            }
            HealthCheck = healthcheck;
           ViewData["CheckedBy"] = new SelectList(_context.Users, "Id", "Email");
           ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Id");
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

            _context.Attach(HealthCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthCheckExists(HealthCheck.Id))
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

        private bool HealthCheckExists(int id)
        {
            return _context.HealthChecks.Any(e => e.Id == id);
        }
    }
}
