using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.UserPage
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public IList<User> User { get;set; } = default!;
        public int PageSize { get; set; } = 4;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public IActionResult OnGet(int? pageIndex)
        {
            var allUser = _userService.GetUsers();
            CurrentPage = pageIndex ?? 1;

            TotalPages = (int)Math.Ceiling((double)allUser.Count / PageSize);
            User = allUser

           .Skip((CurrentPage - 1) * PageSize)
           .Take(PageSize)
           .ToList();

            return Page();
        }
    }
}
