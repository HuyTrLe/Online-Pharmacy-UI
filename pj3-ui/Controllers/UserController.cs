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
    public class UserController : BaseController
    {
        public IConfiguration _configuration;
        private readonly Lazy<IUserService> _userService;
        public UserController(IUserService userService)
        {
            
            _userService = new Lazy<IUserService>(() => userService);
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Detail()
        {
            var userId = HttpContext.Session.GetInt32("UserID").Value;
            Login user = new Login() { ID = userId ,Email = string.Empty, Password = string.Empty};
            var userResult = _userService.Value.GetUser(user);
            return View(userResult);
        }
        public IActionResult DetailUpdate()
        {
           
            return View();
        }


    }
}
