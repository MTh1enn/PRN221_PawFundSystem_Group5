using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly IUserService _userService;
        
        public LoginPageModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string? email = Request.Form["txtEmail"];
            string? password = Request.Form["txtPassword"];
            if (email != null && password != null)
            {
                User account = _userService.GetUserByEmail(email);
                if (account != null && account.Password!.Equals(password) && account.Role.Equals("Staff"))
                {
                    string? roleId = account.Role.ToString() ?? "";
                    string? emailUser = account.Email ?? "";
                    HttpContext.Session.SetString("RoleID", roleId);
                    HttpContext.Session.SetString("EmailUser", email);
                    Response.Redirect("/PetPage");
                }


                else
                    Response.Redirect("/Error");
            }

        }
    }
}
