using Microsoft.AspNetCore.Mvc;
using pj3_ui.Models;
using pj3_ui.Models.User;
using pj3_ui.Service.Home;
using System.Diagnostics;

namespace pj3_ui.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {          
        }

        public void SetUserLogin(UserModel user)
        {
            HttpContext.Session.SetString("Username", user.UserName);
            HttpContext.Session.SetInt32("UserID", user.ID);
            HttpContext.Session.SetInt32("UserRole", user.RoleID);
        }

        public string GetUserLogin()
        {
            return HttpContext.Session.GetString("Username");
        }
    }
}