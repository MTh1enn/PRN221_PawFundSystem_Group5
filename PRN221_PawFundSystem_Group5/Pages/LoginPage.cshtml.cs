using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
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
                if (account != null && account.Password!.Equals(password))
                {
                    string? roleId = account.Role.ToString() ?? "";
                    string? emailUser = account.Email ?? "";
                    int userId = account.Id;
                    HttpContext.Session.SetString("RoleID", roleId);
                    HttpContext.Session.SetString("EmailUser", email);
                    HttpContext.Session.SetInt32("UserId", userId);

                    if (roleId.Contains("ADMIN")) {
                        Response.Redirect("/Admin");
                    }
                    if (roleId.Contains("CUSTOMER")) {
                        Response.Redirect("/HomePage");
                    }
                    if (roleId.Contains("VOLUNTEER"))
                    {
                        Response.Redirect("/VolunteerPage");
                    }
                    if (roleId.Contains("STAFF"))
                    {
                        Response.Redirect("/ShelterStaff/Index");
                    }
                    
                }
                else
                    Response.Redirect("/Error");


            }



        }
    }
}
