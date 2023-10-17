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
            
            var userId = HttpContext.Session.GetInt32("UserID").Value;
            if (userId == null)
                return Redirect("Index");
            Login user = new Login() { ID = userId ,Email = string.Empty, Password = string.Empty};
            var userResult = _userService.Value.GetUser(user);        
            return View(userResult);
        }
        public IActionResult DetailUpdate()
        {
            var userId = HttpContext.Session.GetInt32("UserID").Value;
            if (userId == null)
                return Redirect("Index");
            Login user = new Login() { ID = userId, Email = string.Empty, Password = string.Empty };
            var userResult = _userService.Value.GetUser(user);
            return View(userResult);
        }

        public int UpdateUser(UserModelResult userModelResult)
        {
            foreach(var item in userModelResult.Education)
            {
                item.UserID = HttpContext.Session.GetInt32("UserID").Value;
                item.From = DateTime.Now;
                item.To = DateTime.Now;
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
        public int UploadFile(UploadFile upload)
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
            return userResult;
        }

    }
}
