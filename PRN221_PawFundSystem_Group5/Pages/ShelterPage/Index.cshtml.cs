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

namespace PRN221_PawFundSystem_Group5.Pages.ShelterPage
{
    public class IndexModel : PageModel
    {
        private readonly IShelterService _shelterService;

        public IndexModel(IShelterService shelterService)
        {
            _shelterService = shelterService;
        }

        public IList<Shelter> Shelter { get;set; } = default!;
        public int PageSize { get; set; } = 4;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public IActionResult OnGet(int? pageIndex)
        {
            var allShelter = _shelterService.GetShelters();
            CurrentPage = pageIndex ?? 1;

            TotalPages = (int)Math.Ceiling((double)allShelter.Count / PageSize);
            Shelter = allShelter

           .Skip((CurrentPage - 1) * PageSize)
           .Take(PageSize)
           .ToList();

            return Page();
        }
    }
}
