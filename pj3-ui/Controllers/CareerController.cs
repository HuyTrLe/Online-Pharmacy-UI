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
    public class CareerController : BaseController
    {
        public IConfiguration _configuration;
        private readonly Lazy<IUserService> _userService;
        public CareerController(IUserService userService)
        {
            
            _userService = new Lazy<IUserService>(() => userService);
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Detail()
        {

            return View();
        }
    }
}
