using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_PawFundSystem_Group5.Pages.VolunteerTaskPage
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.PawFundContext _context;

        public DeleteModel(BusinessObjects.Models.PawFundContext context)
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

            var volunteertask = await _context.VolunteerTasks.FirstOrDefaultAsync(m => m.Id == id);

            if (volunteertask == null)
            {
                return NotFound();
            }
            else
            {
                VolunteerTask = volunteertask;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteertask = await _context.VolunteerTasks.FindAsync(id);
            if (volunteertask != null)
            {
                VolunteerTask = volunteertask;
                _context.VolunteerTasks.Remove(VolunteerTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
