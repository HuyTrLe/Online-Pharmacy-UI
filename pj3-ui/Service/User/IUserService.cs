using pj3_ui.Models;
using pj3_ui.Models.User;

namespace pj3_ui.Service.Home
{
    public interface IUserService
    {
        UserModel Login(Login login);
        UserModelResult GetUser(Login user);
        int UpdateUser(UserModelResult userModelResult);
    }
}
