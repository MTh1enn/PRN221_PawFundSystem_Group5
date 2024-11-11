using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service.IService;
using Service.Service;

namespace PRN221_PawFundSystem_Group5.Pages.VolunteerTaskPage
{
    public class DetailsModel : PageModel
    {
        private readonly IVolunteerTaskService _volunteerTaskService;

        public DetailsModel()
        {
            _volunteerTaskService = new VolunteerTaskService();
        }

        public VolunteerTask VolunteerTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteertask = _volunteerTaskService.GetVolunteerTaskById(id);
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
    }
}
