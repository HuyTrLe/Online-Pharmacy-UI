using pj3_ui.Models;
using pj3_ui.Models.User;

namespace pj3_ui.Service.Home
{
    public interface IUserService
    {
        IEnumerable<UserModelResult> GetAllUser();
        UserModel Login(Login login);
        UserModelResult GetUser(Login user);
        int UpdateUser(UserModelResult userModelResult);
        int InsertUser(UserModel user);
        int CheckPassword(ChangePassword CheckPassword);
        int ChangePassword(ChangePassword ChangePassword);
        int UpdateFileName(UploadFile uploadFile);
        int DeleteEducation(DeleteEducation DeleteEducation);
    }
}
