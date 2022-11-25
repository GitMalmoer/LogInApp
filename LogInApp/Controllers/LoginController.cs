using LogInApp.Models;
using LogInApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace LogInApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();

            if(securityService.IsValid(userModel))
            { 
                return View("LoginSucess",userModel);
            }
            else
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}
