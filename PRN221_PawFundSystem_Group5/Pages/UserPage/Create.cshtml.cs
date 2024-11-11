using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.UserPage
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            ViewData["RoleList"] = new List<SelectListItem>
                {
                new SelectListItem { Value = "ADMIN", Text = "ADMIN" },
                new SelectListItem { Value = "STAFF", Text = "STAFF" },
                new SelectListItem { Value = "CUSTOMER", Text = "CUSTOMER" },
                new SelectListItem { Value = "VOLUNTEER", Text = "VOLUNTEER" }
                };
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bool checkCreate = _userService.AddUser(User);

            return RedirectToPage("./Index");
        }
    }
}
