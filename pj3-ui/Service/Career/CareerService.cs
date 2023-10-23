using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Plugins;
using pj3_ui.Models;
using pj3_ui.Models.Career;
using pj3_ui.Models.User;
using pj3_ui.Service.Career;

namespace pj3_ui.Service.Career
{
    public class CareerService : ICareerService
    {
        private AppSetting _appSetting;
        public CareerService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public int InsertCareerJob(CareerJobModel careerJobModel)
        {
            var callRespones = CallApi<CareerJobModel, HttpResultObject>.PostAsJsonAsync(careerJobModel, _appSetting.UrlApi, _appSetting.CareerUrl.InsertCareerJob);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = Convert.ToInt32(jObject["Data"]);
                return result;
            }
            return 0;
        }

        public CareerModel GetCareerByID(CareerGet careerGet)
        {
            var callRespones = CallApi<CareerGet, HttpResultObject>.PostAsJsonAsync(careerGet, _appSetting.UrlApi, _appSetting.CareerUrl.GetCareerByID);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<CareerModel>();
                return result;
            }
            return null;
        }

        public IEnumerable<CareerModel> GetCareers()
        {
            var callRespones = CallApi<IEnumerable<CareerModel>, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.CareerUrl.GetCareer);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<CareerModel>>();
                return result;
            }
            return null;
        }

        public IEnumerable<CareerModel> GetCareersByUserID(CareerGet CareerGet)
        {
            var callRespones = CallApi<CareerGet, HttpResultObject>.PostAsJsonAsync(CareerGet, _appSetting.UrlApi, _appSetting.CareerUrl.GetCareersByUserID);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<CareerModel>>();
                return result;
            }
            return null;
        }

        public CareerModel GetCareerDetailByUserID(CareerGet CareerGet)
        {
            var callRespones = CallApi<CareerGet, HttpResultObject>.PostAsJsonAsync(CareerGet, _appSetting.UrlApi, _appSetting.CareerUrl.GetCareerDetailByUserID);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<CareerModel>();
                return result;
            }
            return null;
        }

        public IEnumerable<CareerJobModel> GetCareerJob()
        {
            var callRespones = CallApi<CareerGet, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.CareerUrl.GetCareerJob);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<CareerJobModel>>();
                return result;
            }
            return null;
        }

        public int InsertCareer(CareerModel CareerModel)
        {
            var callRespones = CallApi<CareerModel, HttpResultObject>.PostAsJsonAsync(CareerModel, _appSetting.UrlApi, _appSetting.CareerUrl.InsertCareer);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result =Convert.ToInt32(jObject["Data"]);
                return result;
            }
            return 0;
        }

        public int UpdateCareer(CareerModel CareerModel)
        {
            var callRespones = CallApi<CareerModel, HttpResultObject>.PostAsJsonAsync(CareerModel, _appSetting.UrlApi, _appSetting.CareerUrl.UpdateCareer);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = Convert.ToInt32(jObject["Data"]);
                return result;
            }
            return 0;
        }

        public int UpdateCareerJob(CareerJobModel CareerJobModel)
        {
            var callRespones = CallApi<CareerJobModel, HttpResultObject>.PostAsJsonAsync(CareerJobModel, _appSetting.UrlApi, _appSetting.CareerUrl.UpdateCareerJob);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = Convert.ToInt32(jObject["Data"]);
                return result;
            }
            return 0;
        }
    }
}
