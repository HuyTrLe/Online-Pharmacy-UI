using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using pj3_ui.Models.User;
using pj3_ui.Service.Home;
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
        public IActionResult IndexAdmin()
        {
            var result = _userService.Value.GetAllUser();
            return View(result);
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult Detail()
        {

            int userId = 0;
            if (HttpContext.Session.TryGetValue("UserID", out byte[] userIdBytes))
            {
                userId = HttpContext.Session.GetInt32("UserID").Value;
            }
            if (userId == 0)
                return Redirect("Index");
            Login user = new Login() { ID = userId, Email = string.Empty, Password = string.Empty };
            var userResult = _userService.Value.GetUser(user);
            return View(userResult);
        }
        public IActionResult DetailUpdate()
        {
            int userId = 0;
            if (HttpContext.Session.TryGetValue("UserID", out byte[] userIdBytes))
            {
                 userId = HttpContext.Session.GetInt32("UserID").Value;
                
            }
            if (userId == 0)
                return Redirect("Index");
            Login user = new Login() { ID = userId, Email = string.Empty, Password = string.Empty };
            var userResult = _userService.Value.GetUser(user);
            return View(userResult);
        }
        public IActionResult DetailAdminUpdate(int ID)
        {
            Login user = new Login() { ID = ID, Email = string.Empty, Password = string.Empty };
            var userResult = _userService.Value.GetUser(user);
            return View(userResult);
        }
        public int UpdateUser(UserModelResult userModelResult)
        {
            foreach (var item in userModelResult.Education)
            {
                item.UserID = HttpContext.Session.GetInt32("UserID").Value;           
            }
            userModelResult.UserModel.ID = HttpContext.Session.GetInt32("UserID").Value;

            var userResult = _userService.Value.UpdateUser(userModelResult);
            return userResult;
        }
        public int CheckPassword(ChangePassword changePassword)
        {
            changePassword.UserID = HttpContext.Session.GetInt32("UserID").Value;
            var userResult = _userService.Value.CheckPassword(changePassword);
            return userResult;
        }
        public int UpdatePassword(ChangePassword changePassword)
        {
            changePassword.UserID = HttpContext.Session.GetInt32("UserID").Value;
            var userResult = _userService.Value.ChangePassword(changePassword);
            return userResult;
        }
        public int InsertUser(UserModel user)
        {
            var userResult = _userService.Value.InsertUser(user);
            return userResult;
        }
        public int DeleteEducation(List<string> id)
        {
            DeleteEducation listID = new DeleteEducation()
            {
                listID = id
            };
            var userResult = _userService.Value.DeleteEducation(listID);
            return userResult;
        }
        public int UploadFile(Upload upload)
        {
            var userResult = 1;
            if (upload.PdfFile == null || upload.PdfFile.Length == 0)
            {
                // Handle the case where the uploaded file is empty or null.
                return 0;
            }
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + upload.PdfFile.FileName;
            string PathFile = @"wwwroot\assets\images\User";
            string filePath = Path.Combine(PathFile, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                upload.PdfFile.CopyTo(stream);
            }
            UploadFile uploadFile = new UploadFile()
            {
                UserID = HttpContext.Session.GetInt32("UserID").Value,
                Filename = uniqueFileName
            };

            var result = _userService.Value.UpdateFileName(uploadFile);
            return userResult;
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("UserRole");
            return Redirect("Index");
        }

    }
}
