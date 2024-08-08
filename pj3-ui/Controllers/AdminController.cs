using Microsoft.AspNetCore.Mvc;
using pj3_ui.Models;
using pj3_ui.Models.User;
using pj3_ui.Service.Home;
using System.Diagnostics;

namespace pj3_ui.Controllers
{
    public class AdminController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Lazy<IHomeService> _homeService;
        private readonly Lazy<IUserService> _userService;
        public AdminController(ILogger<HomeController> logger,IHomeService homeService,IUserService userService)
        {
            _homeService = new Lazy<IHomeService>(() => homeService);
            _userService = new Lazy<IUserService>(() => userService);
            _logger = logger;
        }

        public ActionResult AdminIndex()
        {

            return View();
        }
        public ActionResult AdminRegister()
        {

            return View();
        }
        public ActionResult AdminForgotPassword()
        {

            return View();
        }
        public ActionResult AdminTables()
        {

            return View();
        }
    }
}