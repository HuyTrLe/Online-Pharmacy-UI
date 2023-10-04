using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pj3_ui.Models;
using pj3_ui.Models.User;

namespace pj3_ui.Service.Home
{
    public class UserService : IUserService
    {
        private AppSetting _appSetting;
        public UserService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public UserModel Login(Login login)
        {
            var callRespones = CallApi<Login,HttpResultObject>.PostAsJsonAsync(login, _appSetting.UrlApi, _appSetting.UserUrl.Login);
            if(callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<UserModel>();
                return result;
            }
            return null;
        }
    }
}
