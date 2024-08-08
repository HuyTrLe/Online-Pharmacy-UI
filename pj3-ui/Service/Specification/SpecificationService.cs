using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pj3_ui.Models.Feedback;
using pj3_ui.Models;
using pj3_ui.Models.Product;
using pj3_ui.Models.Career;

namespace pj3_ui.Service.Specification
{
    public class SpecificationService : ISpecificationService
    {
        private AppSetting _appSetting;
        public SpecificationService(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public SpecificationModel CheckUniqueByName(SpecificationModel spec)
        {
            var callRespones = CallApi<SpecificationModel, HttpResultObject>.PostAsJsonAsync(spec, _appSetting.UrlApi, _appSetting.SpecUrl.CheckUniqueByName);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<SpecificationModel>();
                return result;
            }
            return null;
        }

        public int DeleteSpecification(SpecificationModel spec)
        {
            try
            {
                var callRespones = CallApi<SpecificationModel, HttpResultObject>.PostAsJsonAsync(spec, _appSetting.UrlApi, _appSetting.SpecUrl.DeleteSpecification);
                if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
                {
                    string data = JsonConvert.SerializeObject(callRespones.Item1);
                    JObject jObject = JObject.Parse(data);
                    return Convert.ToInt32(jObject["Data"]);
                }

            } catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        public IEnumerable<SpecificationModel> GetSpecification()
        {
            var callRespones = CallApi<IEnumerable<SpecificationModel>, HttpResultObject>.PostAsJsonAsync(null, _appSetting.UrlApi, _appSetting.SpecUrl.GetSpecification);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                var result = jObject["Data"].ToObject<IEnumerable<SpecificationModel>>();
                return result;
            }
            return null;
        }

        public SpecificationModel GetSpecificationByID(int ID)
        {
            var callResponse = CallApi<SpecificationModel, HttpResultObject>.GetAsJsonAsync(null, _appSetting.UrlApi, _appSetting.SpecUrl.GetSpecificationByID);

            if (callResponse.Item2.Code == 200 && callResponse.Item1 != null)
            {
                // Deserialize the JSON content to SpecificationModel
                string jsonData = JsonConvert.SerializeObject(callResponse.Item1.Data);
                return JsonConvert.DeserializeObject<SpecificationModel>(jsonData);
            }

            return null; // Return null if no data is found or the response code is not 200.
        }

        public int InsertSpecification(SpecificationModel spec)
        {
            var callRespones = CallApi<SpecificationModel, HttpResultObject>.PostAsJsonAsync(spec, _appSetting.UrlApi, _appSetting.SpecUrl.InsertSpecification);
            if (callRespones.Item2.Code == 200 && callRespones.Item1 != null)
            {
                string data = JsonConvert.SerializeObject(callRespones.Item1);
                JObject jObject = JObject.Parse(data);
                return Convert.ToInt32(jObject["Data"]);
            }
            return 0;
        }

        public int UpdateSpecification(SpecificationModel spec)
        {
            var callRespones = CallApi<SpecificationModel, HttpResultObject>.PostAsJsonAsync(spec, _appSetting.UrlApi, _appSetting.SpecUrl.UpdateSpecification);
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
