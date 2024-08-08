using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pj3_ui.Models;

namespace pj3_ui.Service.Home
{
    public class HomeService : IHomeService
    {
        private AppSetting _appSetting;
        public HomeService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public IEnumerable<Movie> GetMovies()
        {
            var callRespones = CallApi<IEnumerable<Movie>,HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.ApiUrl.GetMovies);
            if(callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<Movie>>();
                return result;
            }
            return null;
        }
    }
}
