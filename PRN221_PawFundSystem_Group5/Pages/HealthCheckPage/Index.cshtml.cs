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
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.PawFundContext _context;

        public IndexModel(BusinessObjects.Models.PawFundContext context)
        {
            _context = context;
        }

        public IList<HealthCheck> HealthCheck { get;set; } = default!;

        public async Task OnGetAsync()
        {
            HealthCheck = await _context.HealthChecks
                .Include(h => h.CheckedByNavigation)
                .Include(h => h.Pet).ToListAsync();
        }
    }
}
