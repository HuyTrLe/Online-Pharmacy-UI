using Microsoft.AspNetCore.Mvc;
using pj3_ui.Models.User;
using pj3_ui.Service.Home;

namespace pj3_ui.Controllers
{
    public class UserController : Controller
    {
        private readonly Lazy<IUserService> _userService;
        public UserController(IUserService userService)
        {
            _userService = new Lazy<IUserService>(() => userService);
        }
        public IActionResult Index()
        {
            return View();
        }

        public UserModel Login(Login login)
        {
            var result = _userService.Value.Login(login);

            return result;
        }
    }
}
