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
    public class UserController : Controller
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

        public UserModel Login(Login login)
        {

            var result = _userService.Value.Login(login);
            if(result != null)
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", result.ID.ToString()),
                        new Claim("DisplayName", result.UserName),
                        new Claim("Email", result.Email),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                //claims.AddRange(new Claim("Token", token));

            }
            return result;
        }
    }
}
