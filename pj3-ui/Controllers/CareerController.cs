using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Packaging;
using pj3_ui.Models.Career;
using pj3_ui.Models.User;
using pj3_ui.Service.Career;
using pj3_ui.Service.Home;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pj3_ui.Controllers
{
    public class CareerController : BaseController
    {
        public IConfiguration _configuration;
        private readonly Lazy<ICareerService> _careerService;
        public CareerController(ICareerService careerService)
        {
            _careerService = new Lazy<ICareerService>(() => careerService);
        }
        public IActionResult Index()
        {
            var result = _careerService.Value.GetCareers();
            if (HttpContext.Session.TryGetValue("UserID", out byte[] userIdBytes))
            {
                foreach (var item in result)
                {
                    item.UserID = HttpContext.Session.GetInt32("UserID").Value;
                }
            }
            return View(result);
        }
        public IActionResult Detail(string result)
        {
            var career = JsonConvert.DeserializeObject<CareerModel>(result);
            if(career != null)
            {
                if (HttpContext.Session.TryGetValue("UserID", out byte[] userIdBytes))
                {
                    career.UserID = HttpContext.Session.GetInt32("UserID").Value;
                }
            }
            
            return View(career);
        }
        public IActionResult GetDetailInfor(CareerGet careerGet)
        {
            var result = _careerService.Value.GetCareerByID(careerGet);
            if (result != null)
            {
                return Json(new { success = true, result = result });
            }
            return Json(new { success = false, error = "Không tìm thấy dữ liệu" });
        }

        public IActionResult InsertCareerJob(CareerJobGet careerGet)
        {
            CareerJobModel careerJobModel = new CareerJobModel() { 
                JobID = careerGet.JobID,
                UserID = HttpContext.Session.GetInt32("UserID").Value
        };
            var result = _careerService.Value.InsertCareerJob(careerJobModel);
            if (result > 0)
            {
                return Json(new { success = true, result = result });
            }
            return Json(new { success = false, error = "Không tìm thấy dữ liệu" });
        }
    }
}
