using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging;
using pj3_ui.Models.Career;
using pj3_ui.Models.User;
using pj3_ui.Service.Career;
using pj3_ui.Service.Home;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace pj3_ui.Controllers
{
    public class CareerController : BaseController
    {
        public IConfiguration _configuration;
        private readonly Lazy<ICareerService> _careerService;
        private readonly Lazy<IUserService> _userService;
        public CareerController(ICareerService careerService, IUserService userService)
        {
            _careerService = new Lazy<ICareerService>(() => careerService);
            _userService = new Lazy<IUserService>(() => userService);
        }
        public IActionResult Index()
        {
            IEnumerable<CareerModel> result = new List<CareerModel>();
            if (HttpContext.Session.TryGetValue("UserID", out byte[] userIdBytes))
            {
                CareerGet careerGet = new CareerGet()
                {
                    UserID = HttpContext.Session.GetInt32("UserID").Value
                };
                result = _careerService.Value.GetCareersByUserID(careerGet);
                ViewBag.UserId = HttpContext.Session.GetInt32("UserID").Value;
                foreach (var item in result)
                {
                    item.UserID = HttpContext.Session.GetInt32("UserID").Value;
                }
            }
            else
            {
                ViewBag.UserId = 0;
                result = _careerService.Value.GetCareers();
            }


            return View(result);
        }
        public IActionResult IndexAdmin()
        {
            var result = _careerService.Value.GetAllCareers();
            return View(result);
        }

        public IActionResult DetailAdminUpdate(int ID)
        {
            CareerGet careerGet = new CareerGet();
            careerGet.ID = ID;
            var result = _careerService.Value.GetCareerByID(careerGet);
            return View(result);
        }
        public IActionResult InsertCareer()
        {
            return View();
        }
        public IActionResult IndexAdminCareerJobApprove()
        {
            var result = _careerService.Value.GetCareerJobAdmin();
            var resultModel = result.Where(x => x.Status != 0);
            return View(resultModel.ToList());
        }     
        public int InsertCareerAdmin(CareerModel careerModel)
        {
            var result = _careerService.Value.InsertCareer(careerModel);
            return result;
        }
        public int UpdateCareer(CareerModel careerModel)
        {
            var result = _careerService.Value.UpdateCareer(careerModel);
            return result;
        }
        public IActionResult UpdateStatusCareerJob(UpdateStatusCareerJob careerModel)
        {
            var result = _careerService.Value.UpdateStatusCareerJob(careerModel);
            return Redirect("IndexAdminCareerJob");
        }
        public IActionResult IndexAdminCareerJob()
        {
            var result = _careerService.Value.GetCareerJobAdmin();
            var resultModel = result.Where(x => x.Status == 0);
            return View(resultModel.ToList());
        }
        public IActionResult Detail(string data)
        {
            CareerModel result = new CareerModel();
            var career = JsonConvert.DeserializeObject<CareerGet>(data);
            if (career.UserID != 0)
            {
                result = _careerService.Value.GetCareerDetailByUserID(career);
                if (result != null)
                {
                    if (HttpContext.Session.TryGetValue("UserID", out byte[] userIdBytes))
                    {
                        result.UserID = HttpContext.Session.GetInt32("UserID").Value;
                        ViewBag.UserId = HttpContext.Session.GetInt32("UserID").Value;
                    }
                    else
                    {
                        ViewBag.UserId = 0;
                    }
                }
                else
                {
                    ViewBag.UserId = 0;
                }
            }
            else
            {
                result = _careerService.Value.GetCareerByID(career);
            }
            return View(result);
        }
        public IActionResult GetDetailInfor(CareerGet careerGet)
        {

            if (HttpContext.Session.TryGetValue("UserID", out byte[] userIdBytes))
            {
                careerGet.UserID = HttpContext.Session.GetInt32("UserID").Value;
                //result = _careerService.Value.GetCareerDetailByUserID(careerGet);

            }
            else
            {
                //result = _careerService.Value.GetCareerByID(careerGet);
            }
            return Json(new { success = true, result = careerGet });
        }

        public IActionResult InsertCareerJob(CareerJobGet careerGet)
        {
            CareerJobModel careerJobModel = new CareerJobModel()
            {
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

        public IActionResult CheckResume()
        {

            var result = _userService.Value.GetUser(new Login() { ID = HttpContext.Session.GetInt32("UserID").Value });
            if (result != null)
            {
                if (result.UserModel.FileName != null)
                {
                    return Json(new { success = true, result = 1 });
                }
                else
                {
                    return Json(new { success = true, result = 0 });
                }

            }
            return Json(new { success = false, result = 0, error = "Không tìm thấy dữ liệu" });
        }
    }
}
