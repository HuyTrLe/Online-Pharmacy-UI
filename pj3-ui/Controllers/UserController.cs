using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;
using pj3_ui.Models.User;
using pj3_ui.Service.Home;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pj3_ui.Controllers
{
    public class UserController : Controller
    {
        public IConfiguration _configuration;
        private readonly Lazy<IUserService> _userService;
        public UserController(IUserService userService)
        {
            
            _userService = new Lazy<IUserService>(() => userService);
        }
        public IActionResult Index()
        {
            if (ViewBag.UserName != null)
                return View();

            return View();
        }

       
    }
}
