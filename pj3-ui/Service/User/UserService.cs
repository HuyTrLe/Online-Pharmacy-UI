using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Plugins;
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

        public int ChangePassword(ChangePassword ChangePassword)
        {
            var callRespones = CallApi<ChangePassword, HttpResultObject>.PostAsJsonAsync(ChangePassword, _appSetting.UrlApi, _appSetting.UserUrl.ChangePassword);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public int CheckPassword(ChangePassword CheckPassword)
        {
            var callRespones = CallApi<ChangePassword, HttpResultObject>.PostAsJsonAsync(CheckPassword, _appSetting.UrlApi, _appSetting.UserUrl.CheckPassword);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public int DeleteEducation(DeleteEducation DeleteEducation)
        {
            var callRespones = CallApi<DeleteEducation, HttpResultObject>.PostAsJsonAsync(DeleteEducation, _appSetting.UrlApi, _appSetting.UserUrl.DeleteEducation);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public UserModelResult GetUser(Login user)
        {
            var callRespones = CallApi<Login, HttpResultObject>.PostAsJsonAsync(user, _appSetting.UrlApi, _appSetting.UserUrl.GetUser);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<UserModelResult>();
                return result;
            }
            return null;
        }

        public int InsertUser(UserModel user)
        {
            var callRespones = CallApi<UserModel, HttpResultObject>.PostAsJsonAsync(user, _appSetting.UrlApi, _appSetting.UserUrl.InsertUser);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
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

        public int UpdateFileName(UploadFile uploadFile)
        {
            var callRespones = CallApi<UploadFile, HttpResultObject>.PostAsJsonAsync(uploadFile, _appSetting.UrlApi, _appSetting.UserUrl.UpdateFileName);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public int UpdateUser(UserModelResult userModelResult)
        {
            var callRespones = CallApi<UserModelResult, HttpResultObject>.PostAsJsonAsync(userModelResult, _appSetting.UrlApi, _appSetting.UserUrl.UpdateUser);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }
    }
}
