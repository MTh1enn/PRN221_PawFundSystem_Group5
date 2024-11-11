using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.UserPage
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            ViewData["RoleList"] = new List<SelectListItem>
                {
                new SelectListItem { Value = "ADMIN", Text = "ADMIN" },
                new SelectListItem { Value = "STAFF", Text = "STAFF" },
                new SelectListItem { Value = "CUSTOMER", Text = "CUSTOMER" },
                new SelectListItem { Value = "VOLUNTEER", Text = "VOLUNTEER" }
                };
            ViewData["Status"] = new List<SelectListItem>
                {
                new SelectListItem { Value = "ACTIVE", Text = "ACTIVE" },
                new SelectListItem { Value = "INACTIVE", Text = "INACTIVE" },
                };
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

            bool checkUpdate = _userService.UpdateUser(User);


            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            return _userService.GetUserById(id) != null;
        }
    }
}
