using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_PawFundSystem_Group5.Pages.VolunteerTaskPage
{
    public class EditModel : PageModel
    {
        private readonly BusinessObjects.Models.PawFundContext _context;

        public EditModel(BusinessObjects.Models.PawFundContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VolunteerTask VolunteerTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteertask =  await _context.VolunteerTasks.FirstOrDefaultAsync(m => m.Id == id);
            if (volunteertask == null)
            {
                return NotFound();
            }
            VolunteerTask = volunteertask;
           ViewData["AssignedBy"] = new SelectList(_context.Users, "Id", "Email");
           ViewData["AssignedTo"] = new SelectList(_context.Users, "Id", "Email");
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

            _context.Attach(VolunteerTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerTaskExists(VolunteerTask.Id))
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

        private bool VolunteerTaskExists(int id)
        {
            return _context.VolunteerTasks.Any(e => e.Id == id);
        }
    }
}
