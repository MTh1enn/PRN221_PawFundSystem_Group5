using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Service.IService;
using Service.Service;
using System.Drawing.Printing;

namespace PRN221_PawFundSystem_Group5.Pages.HealthCheckPage
{
    public class IndexModel : PageModel
    {
        private readonly IHealthCheckService _healthCheckService;

        public IndexModel(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        public IList<HealthCheck> HealthCheck { get;set; } = default!;
        public int PageSize { get; set; } = 4;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public IActionResult OnGet(int? pageIndex)
        {
            var allChecks = _healthCheckService.GetHealthChecks();
            CurrentPage = pageIndex ?? 1;

            TotalPages = (int)Math.Ceiling((double)allChecks.Count / PageSize);
            HealthCheck = allChecks
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return Page();
        }
    }
}
