using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_PawFundSystem_Group5.Pages.HealthCheckPage
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObjects.Models.PawFundContext _context;

        public DetailsModel(BusinessObjects.Models.PawFundContext context)
        {
            _context = context;
        }

        public HealthCheck HealthCheck { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthcheck = await _context.HealthChecks.FirstOrDefaultAsync(m => m.Id == id);
            if (healthcheck == null)
            {
                return NotFound();
            }
            else
            {
                HealthCheck = healthcheck;
            }
            return Page();
        }
    }
}
