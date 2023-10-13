using Microsoft.AspNetCore.Mvc;
using pj3_ui.Models;
using pj3_ui.Models.User;
using pj3_ui.Service.Home;
using System.Diagnostics;

namespace pj3_ui.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Lazy<IHomeService> _homeService;
        private readonly Lazy<IUserService> _userService;
        public HomeController(ILogger<HomeController> logger,IHomeService homeService,IUserService userService)
        {
            _homeService = new Lazy<IHomeService>(() => homeService);
            _userService = new Lazy<IUserService>(() => userService);
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData["User"] != null)
            {
                ViewBag.UserName = TempData["User"];
            }
            return View();
        }

        public UserModel Login(Login login)
        {

            var result = _userService.Value.Login(login);
            if(result != null)
            {
               SetUserLogin(result);
            }             
            return result;
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Shop()
        {

            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }
		public ActionResult Recruitment()
		{

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}