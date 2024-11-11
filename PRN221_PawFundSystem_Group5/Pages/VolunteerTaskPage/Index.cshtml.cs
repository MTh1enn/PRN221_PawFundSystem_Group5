using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repository.IRepository;
using Service.IService;
using Service.Service;

namespace PRN221_PawFundSystem_Group5.Pages.VolunteerTaskPage
{
    public class IndexModel : PageModel
    {
        private readonly IVolunteerTaskService _volunteerTaskService;

        public IndexModel(IVolunteerTaskService volunteerTaskService)
        {
            _volunteerTaskService = volunteerTaskService;
        }

        public IList<VolunteerTask> VolunteerTask { get;set; } = default!;

        public int PageSize { get; set; } = 4;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        public IActionResult OnGet(int? pageIndex)
        {
            var allTask = _volunteerTaskService.GetVolunteerTasks();
            CurrentPage = pageIndex ?? 1;

            TotalPages = (int)Math.Ceiling((double)allTask.Count / PageSize);
            VolunteerTask = allTask

           .Skip((CurrentPage - 1) * PageSize)
           .Take(PageSize)
           .ToList();

            return Page();
        }
    }
}
