using Microsoft.AspNetCore.Mvc;
using pj3_ui.Models;
using pj3_ui.Service.Home;
using System.Diagnostics;

namespace pj3_ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Lazy<IHomeService> _homeService;
        public HomeController(ILogger<HomeController> logger,IHomeService homeService)
        {
            _homeService = new Lazy<IHomeService>(() => homeService);
            _logger = logger;
        }

        public IActionResult Index()
        {
            var result = _homeService.Value.GetMovies();
            return View(result);
        }

        public IActionResult Privacy()
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